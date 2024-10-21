using AutoMapper;
using EntegrasyonSistemi.DatabaseObject;
using EntegrasyonSistemi.Entity;
using EntegrasyonSistemi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntegrasyonSistemi.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserManager userManager;
        private readonly IMapper mapper;
        public UserController(IMapper mapper, IUserManager userManager)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }

        [HttpPost("/addUser")]
        public async Task<string> AddUser([FromBody]AddUserDto userDto)
        {
            return await userManager.addUser(mapper.Map(userDto,new User()));
        }

        [HttpPost("/getUser")]
        public async Task<List<User>> GetAll()
        {
            return await userManager.getAll();
        }
    }
}
