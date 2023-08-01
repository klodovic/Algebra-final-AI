using AutoMapper;
using CompanyWeb.ModelDTO;
using CompanyWeb.Models;


namespace CompanyWeb.Configuration
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
