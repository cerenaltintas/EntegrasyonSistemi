using EntegrasyonSistemi.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntegrasyonSistemi.Repository
{
    public interface IUserRepository
    {
        Task<string> AddUser(User user);

        Task<List<User>> GetAll();
    }
}
