using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAuthenticateRepository
    {
        Task<(bool isValid, int userId, string userName)> LoginValidateAsync(string email, string password);
    }
}
