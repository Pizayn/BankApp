using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Deneme.WebApi.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public decimal CreditScore { get; set; }
        public decimal TotalBalance { get; set; }
        public DateTime RegistrationTime { get; set; }
        [Required]
        public long Tckno { get; set; }
        [Required]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "You must specify password between 6 and 12")]
        public string Password { get; set; }
    }
}
