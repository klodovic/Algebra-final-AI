using CompanyWeb.ModelDTO;

namespace CompanyWeb.Services
{
    public interface IAuthService
    {
        Task<T> LoginAsync<T>(LoginRequestDTO obj);
        Task<T> RegisterAsync<T>(RegisterUserDTO obj);

    }
}
