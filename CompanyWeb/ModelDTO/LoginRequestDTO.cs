using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CompanyWeb.ModelDTO;

public class LoginRequestDTO
{

    [Required(ErrorMessage = "Ovo polje je obavezno")]
    public string Email { get; set; }



    [Required(ErrorMessage = "Ovo polje je obavezno")]
    public string Password { get; set; }
}
