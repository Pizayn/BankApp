using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DenemeApi.Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Deneme.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Supplement")]
    public class SupplementController : Controller
    {
        private ISupplementService _supplementService;

        public SupplementController(ISupplementService supplementService)
        {
            _supplementService = supplementService;
        }

        [HttpGet]
        [Route("supplements")]
        public ActionResult GetSupplements()
        {
            var supplements = _supplementService.GetAll();
            return Ok(supplements);
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult GetSupplementsById(int id)
        {
            var supplements = _supplementService.GetSuppplementById(id);
            return Ok(supplements);
        }
    }
}