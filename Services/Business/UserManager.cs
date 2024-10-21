using EntegrasyonSistemi.Entity;
using EntegrasyonSistemi.Interfaces;
using EntegrasyonSistemi.Models;
using EntegrasyonSistemi.Repository;
using EntegrasyonSistemi.Services.Utility;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntegrasyonSistemi.Services.Business
{
    public class UserManager : IUserManager
    {
        string Message;
        private readonly IUserRepository userResository;
        private readonly IntegrationDatabaseContext db;
        public UserManager(IUserRepository userManager, IntegrationDatabaseContext integrationDatabaseContext)
        {
            userResository = userManager;
            db = integrationDatabaseContext;
        }

        public async Task<string> addUser(User user)
        {
            if (!RegexCheckUtility.IsValidEmail(user.Email))
            {
                Message = "Email formatı geçersiz";
            }
            else
            {
               if(db.users.FirstOrDefaultAsync(u => u.Email == user.Email).Result != null)
                {
                    Message = "Zaten Kayıtlı bir Email Girdiniz";
                } 
                else
                {
                   if(SignupCheckUtility.isValidSign(user).Success)
                    {
                        Message = await userResository.AddUser(user);
                    } else
                    {
                        Message = SignupCheckUtility.isValidSign(user).Message;
                    }

                }
            }
            return Message;
        }

        public Task<List<User>> getAll()
        {
            return userResository.GetAll();
        }
    }
}
