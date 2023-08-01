using CompanyAPI.Model;
using CompanyAPI.ModelDTO;
using CompanyAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CompanyAPI.Controllers
{
    [Route("api/usersAuth")]
    [ApiController]
    public class UsersController : Controller
    {
        public readonly IUserRepository _userRepo;
        protected ApiResponse _response = new();

        public UsersController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }


        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
        {
            var loginResponse = await _userRepo.Login(model);
            if (loginResponse.User == null || string.IsNullOrEmpty(loginResponse.Token))
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessage.Add("E-mail ili lozinka nisu ispravni!");
                return BadRequest(_response);
            }

            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = loginResponse;
            return Ok(_response);
        }


        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] RegisterUserDTO model)
        {
            bool ifEmailIsUnique = _userRepo.IsUniqueUser(model.Email);
            if (!ifEmailIsUnique)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessage.Add("E-mail adresa već postoji!");
                return BadRequest(_response);
            }
            var user = _userRepo.Register(model);
            if (user == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessage.Add("Dogodila se greška prilikom registracije!");
                return BadRequest(_response);
            }

            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }
    }
}
