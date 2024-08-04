using DataAcces.EFCore;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Repositories
{
    public class AuthenticateRepository : IAuthenticateRepository
    {
        protected readonly InventarioContext _context;

         public AuthenticateRepository(InventarioContext context)
        {
            _context = context;
        }

        public async Task<(bool isValid, int userId, string userName)> LoginValidateAsync(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                return (true, user.UserId, user.UserName);
            }
            else
            {
                return (false, 0, null);
            }
        }
    }
}
