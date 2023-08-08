using CompanyWeb.ModelDTO;
using CompanyWeb.Models;

namespace CompanyWeb.Services
{
    public interface IAuthService
    {
        Task<T> LoginAsync<T>(LoginRequestDTO obj);
        Task<T> RegisterAsync<T>(RegistrationRequestDTO obj);
        Task<T> GetAsync<T>(int id, string token);
        Task<T> UpdateAsync<T>(UserDTO user, string token);
        Task<T> DeleteAsync<T>(int id, string token);
    }
}
