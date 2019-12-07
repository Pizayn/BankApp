using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deneme.WebApi.Entities
{
    public class User
    {
        public int Id { get; set; }
        public long TckNo { get; set; }
        public int Age { get; set; }

        public byte[] PasswordSalt { get; set; }

        public byte[] PasswordHash { get; set; }
    }
}
