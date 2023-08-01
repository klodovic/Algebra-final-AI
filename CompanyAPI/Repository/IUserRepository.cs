using CompanyAPI.Model;
using CompanyAPI.ModelDTO;

namespace CompanyAPI.Repository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string email);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<User> Register(RegisterUserDTO registerUserDTO);

    }
}
