using CompanyAPI.Model;

namespace CompanyAPI.ModelDTO
{
    public class LoginResponseDTO
    {
        public User User { get; set; }
        public string Token { get; set; }
    }
}
