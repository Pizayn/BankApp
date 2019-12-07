using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deneme.WebApi.Dtos
{
    public class UserForLoginDto
    {
        public long Tckno { get; set; }
        public string Password { get; set; }
    }
}
