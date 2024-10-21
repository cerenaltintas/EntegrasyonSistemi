using AutoMapper;
using EntegrasyonSistemi.DatabaseObject;
using EntegrasyonSistemi.Entity;

namespace EntegrasyonSistemi.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<AddUserDto, User>();
        }
    }
}
