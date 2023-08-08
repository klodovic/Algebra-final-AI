using System.ComponentModel.DataAnnotations;

namespace CompanyWeb.ModelDTO
{
    public class RegistrationRequestDTO
    {
        [Required(ErrorMessage = "Ovo polje je obavezno")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno")]
        public string Password { get; set; }
    }
}
