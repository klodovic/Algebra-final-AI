using CompanyWeb.ModelDTO;
using CompanyWeb.Models;
using CompanyWeb.Utility;

namespace CompanyWeb.Services
{
    public class CompanyService : BaseService, ICompanyService
    {
        //private const string ext = "id:int?id=";
        private readonly IHttpClientFactory _httpClient;
        private string companyUrl;
        public CompanyService(IHttpClientFactory httpClient, IConfiguration configuration) : base(httpClient)
        {
            _httpClient = httpClient;
            companyUrl = configuration.GetValue<string>("ServiceUrls:ApiUrl");
        }


        //Get all organizations
        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = companyUrl + "/api/organization",
                Token = token
            });
        }

        //Get single organization by id
        public Task<T> GetAsync<T>(int id, string token)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = companyUrl + "/api/organization/id:int?id=" + id,
                Token = token
            });
        }

        //Create new Organization
        public Task<T> CreateAsync<T>(OrganizationCreateDTO entity, string token)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.POST,
                Data = entity,
                Url = companyUrl + "/api/organization",
                Token = token
            });
        }

        //Delete Organization
        public Task<T> DeleteAsync<T>(int id, string token)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.DELETE,
                Url = companyUrl + "/api/organization/id:int?id=" + id,
                Token = token
            });
        }

        //Update Organization (id)
        public Task<T> UpdateAsync<T>(OrganizationDTO entity, string token)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.PUT,
                Data = entity,
                Url = companyUrl + "/api/organization/id:int?id=" + entity.Id,
                Token = token
            });
        }


    }
}
