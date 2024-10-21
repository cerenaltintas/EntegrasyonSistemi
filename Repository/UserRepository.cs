using EntegrasyonSistemi.Entity;
using EntegrasyonSistemi.Interfaces;
using EntegrasyonSistemi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntegrasyonSistemi.Repository
{
    public class UserRepository : IUserRepository
    {
        IntegrationDatabaseContext db;

        public UserRepository(IntegrationDatabaseContext ıntegrationDatabaseContext)
        {
            db = ıntegrationDatabaseContext;
        }

        public async Task<string> AddUser(User user)
        {
            await db.users.AddAsync(user);
            await db.SaveChangesAsync();
            return user.Name;
        }

        public async Task<List<User>> GetAll()
        {
           return await db.users.ToListAsync();
        }
    }
}
