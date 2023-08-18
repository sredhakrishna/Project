using AutoMapper;
using ParcelProject.DTO.Registration;
using ParcelProject.Model;

namespace ParcelProject.DTO.Mapping
{
    public class Automapping : Profile
    {
        public Automapping()
        {
            CreateMap<AdminUser, Registrationdto>().ReverseMap();
        }
    }
}
