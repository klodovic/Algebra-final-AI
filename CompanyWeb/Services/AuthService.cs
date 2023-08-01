using CompanyWeb.ModelDTO;
using CompanyWeb.Models;
using CompanyWeb.Utility;

namespace CompanyWeb.Services
{
    public class AuthService : BaseService, IAuthService
    {
        //private const string ext = "id:int?id=";
        private readonly IHttpClientFactory _httpClient;
        private string url;
        public AuthService(IHttpClientFactory httpClient, IConfiguration configuration) : base(httpClient)
        {
            _httpClient = httpClient;
            url = configuration.GetValue<string>("ServiceUrls:ApiUrl");
        }


        public Task<T> LoginAsync<T>(LoginRequestDTO obj)
        {
            return SendAsync<T>(new ApiRequest
            {
                ApiType = StaticDetails.ApiType.POST,
                Data= obj,
                Url = url + "/api/usersAuth/login"
            });
        }

        public Task<T> RegisterAsync<T>(RegisterUserDTO obj)
        {
            return SendAsync<T>(new ApiRequest
            {
                ApiType = StaticDetails.ApiType.POST,
                Data = obj,
                Url = url + "/api/usersAuth/register"
            });
        }
    }
}
