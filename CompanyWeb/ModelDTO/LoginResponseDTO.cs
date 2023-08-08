using CompanyWeb.Models;

namespace CompanyWeb.ModelDTO
{
    public class LoginResponseDTO
    {
        public UserDTO User { get; set; }
        public string Token { get; set; }
    }
}
