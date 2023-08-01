using AutoMapper;
using CompanyAPI.Model;
using CompanyAPI.ModelDTO;

namespace CompanyAPI.Configuration
{
    public class MapperInitlizer : Profile
    {
        public MapperInitlizer() 
        {
            CreateMap<Organization, OrganizationDTO>().ReverseMap();
            CreateMap<Organization, OrganizationCreateDTO>().ReverseMap();
        }
    }
}
