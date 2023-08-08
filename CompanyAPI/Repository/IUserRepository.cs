using CompanyAPI.Model;
using CompanyAPI.ModelDTO;

namespace CompanyAPI.Repository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string email);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<LocalUser> Register(RegistrationRequestDTO registerUserDTO);
        Task<LocalUser> GetUser(int id);
        Task UpdateAsync(LocalUser user);
        Task DeleteAsync(LocalUser user);
    }
}
