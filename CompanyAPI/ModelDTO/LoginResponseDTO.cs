using CompanyAPI.Model;

namespace CompanyAPI.ModelDTO
{
    public class LoginResponseDTO
    {
        public LocalUser User { get; set; }
        public string Token { get; set; }
    }
}
