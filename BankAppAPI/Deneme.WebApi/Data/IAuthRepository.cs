using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Deneme.WebApi.Entities;
using DenemeApi.Entities.Concrete;

namespace Deneme.WebApi.Data
{
   public interface IAuthRepository
    {
        Task<User> Register(User user, string password);
        Task<User> Login(long tckno, string password);
        Task<bool> UserExists(long tckno);
    }
}
