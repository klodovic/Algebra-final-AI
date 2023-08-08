using CompanyWeb.ModelDTO;
using CompanyWeb.Models;
using CompanyWeb.Utility;

namespace CompanyWeb.Services
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly IHttpClientFactory _httpClient;
        private string url;
        public AuthService(IHttpClientFactory httpClient, IConfiguration configuration) : base(httpClient)
        {
            _httpClient = httpClient;
            url = configuration.GetValue<string>("ServiceUrls:ApiUrl");
        }


        //Login user
        public Task<T> LoginAsync<T>(LoginRequestDTO obj)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.POST,
                Data= obj,
                Url = url + "/api/UsersAuth/login"
            });
        }

        //Register user
        public Task<T> RegisterAsync<T>(RegistrationRequestDTO obj)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.POST,
                Data = obj,
                Url = url + "/api/UsersAuth/reg"
            });
        }

        //Get single organization by id
        public Task<T> GetAsync<T>(int id, string token)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = url + "/api/usersAuth/id:int?id=" + id,
                Token = token
            });
        }

        //Update user by id
        public Task<T> UpdateAsync<T>(UserDTO user, string token)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.PUT,
                Data = user,
                Url = url + "/api/usersAuth/id:int?id=" + user.Id,
                Token = token
            });
        }

        //Delete user by id
        public Task<T> DeleteAsync<T>(int id, string token)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = StaticDetails.ApiType.DELETE,
                Url = url + "/api/usersAuth/id:int?id=" + id,
                Token = token
            });
        }

    }
}
