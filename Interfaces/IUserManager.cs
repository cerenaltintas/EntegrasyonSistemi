using EntegrasyonSistemi.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntegrasyonSistemi.Interfaces
{
    public interface IUserManager
    {
        Task<string> addUser(User user);

        Task<List<User>> getAll();
    }
}
