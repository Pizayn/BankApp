using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DatingApp.API.Helpers;
using Deneme.WebApi.Data;
using Deneme.WebApi.Dtos;
using Deneme.WebApi.Entities;
using Deneme.WebApi.Model;
using DenemeApi.Business.Abstract;
using DenemeApi.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Deneme.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository repo;
        private readonly IConfiguration configuration;//bunlar nıye yesılki hep öle resharper var o yüzden
        private ICustomerService _customerService;

        public AuthController(IAuthRepository repo, IConfiguration configuration, ICustomerService customerService)
        {
            this.repo = repo;
            this.configuration = configuration;
            _customerService = customerService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserForRegisterDto userForRegisterDto)
        {
            //validate request
            //Validation için eğer apicontroller'ı silersek parametre bölümüne [FromBody]eklenmeli daha sonra hata mesajı verdirmek için
            //If(!ModelState.IsValid)
            //  return BadRequest(ModelState);  
            if (await repo.UserExists(userForRegisterDto.Tckno))
                return BadRequest("TCKNo ile kayıt var.");
            var userToCreate = new User()
            {
                TckNo = userForRegisterDto.Tckno,
                Age = userForRegisterDto.DateOfBirth.CalculateAge()
            };
            Customer customer=new Customer()
            {
                CreditScore = 0,
                DateOfBirth = userForRegisterDto.DateOfBirth,
                Mail = userForRegisterDto.Email,
                Name = userForRegisterDto.FirstName,
                PhoneNumber = userForRegisterDto.PhoneNumber,
                RegistrationTime = DateTime.Now,
                Surname = userForRegisterDto.LastName,
                TckNo = userForRegisterDto.Tckno,
                TotalBalance = 0,
                CountsOfAccounts = 1
            };
            _customerService.Add(customer);
            var createdUser = await repo.Register(userToCreate, userForRegisterDto.Password);
            return StatusCode(201);//StatusCode(201)--basarılı old mesaj
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]UserForLoginDto userForLoginDto)
        {
            try
            {
                var userFromRepo = await repo.Login(userForLoginDto.Tckno, userForLoginDto.Password);
                if (userFromRepo == null)
                    return Unauthorized();
                var claims = new[]
                {
                new Claim(ClaimTypes.NameIdentifier,userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.DateOfBirth, userFromRepo.Age.ToString())
            };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("AppSettings:Token").Value));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = creds
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return Ok(new
                {
                    token = tokenHandler.WriteToken(token)
                });
            }
            catch
            {
                return StatusCode(500, "Something went wrong!");
            }
        }
    }
}