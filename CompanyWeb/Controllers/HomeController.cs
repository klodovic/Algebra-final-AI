using CompanyWeb.Models;
using CompanyWeb.ModelDTO;
using CompanyWeb.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CompanyWeb.Model;
using Newtonsoft.Json;
using CompanyWeb.Utility;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace CompanyWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAuthService _authService;

        public HomeController(IAuthService authService)
        {
            _authService = authService;
        }


        //Login
        [HttpGet]
        public IActionResult Index()
        {
            LoginRequestDTO obj = new();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginRequestDTO obj)
        {
            //session
            ApiResponse response = await _authService.LoginAsync<ApiResponse>(obj);
            if (response != null && response.IsSuccess)
            {
                LoginResponseDTO model = JsonConvert.DeserializeObject<LoginResponseDTO>(Convert.ToString(response.Result));

                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, model.User.Id.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Name, model.User.Name));
                identity.AddClaim(new Claim(ClaimTypes.Email, model.User.Email));
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme ,principal);

                HttpContext.Session.SetString(StaticDetails.SessionToken, model.Token);
                return RedirectToAction("Index", "Company");
            }
            else
            {
                ModelState.AddModelError("ErrorMessage", response.ErrorMessage.FirstOrDefault());
            }
            return View(obj);
        }



        //Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegistrationRequestDTO obj)
        {
            ApiResponse result = await _authService.RegisterAsync<ApiResponse>(obj);
            if (result != null && !result.IsSuccess)
            {
                foreach (var errorMessage in result.ErrorMessage)
                {
                    ModelState.AddModelError("Email", errorMessage);
                }
                return View();
            }
            return RedirectToAction("Index");
        }

        //Logout
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.SetString(StaticDetails.SessionToken, "");
            return RedirectToAction("Index", "Home");
        }

        //AccessDenied
        public IActionResult AccessDenied()
        {
            return View();
        }

        //Info
        public IActionResult Info()
        {
            return View();
        }



        //Profile
        public async Task<IActionResult> Profile()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            int id = int.Parse(userIdClaim.Value);
            if (id != null)
            {
                var response = await _authService.GetAsync<ApiResponse>(id, HttpContext.Session.GetString(StaticDetails.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    UserDTO user = JsonConvert.DeserializeObject<UserDTO>(Convert.ToString(response.Result));
                    return View(user);
                }
            }
            return RedirectToAction("AccessDenied");
        }

        //Display user data
        public async Task<IActionResult> Update(int id, string token)
        {
            var response = await _authService.GetAsync<ApiResponse>(id, HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (response != null && response.IsSuccess)
            {
                UserDTO user = JsonConvert.DeserializeObject<UserDTO>(Convert.ToString(response.Result));
                return View(user);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UserDTO user, string token)
        {
            if (ModelState.IsValid)
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
                int userId = int.Parse(userIdClaim.Value);

                var response = await _authService.UpdateAsync<ApiResponse>(user, HttpContext.Session.GetString(StaticDetails.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(Profile));
                }
            }
            return View(user);
        }


        //Delete user
        public async Task<IActionResult> Delete(int id, string token)
        {
            var response = await _authService.GetAsync<ApiResponse>(id, HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (response != null && response.IsSuccess)
            {
                UserDTO user = JsonConvert.DeserializeObject<UserDTO>(Convert.ToString(response.Result));
                return View(user);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(UserDTO model, string token)
        {
            var response = await _authService.DeleteAsync<ApiResponse>(model.Id, HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (response != null && response.IsSuccess)
            {
                await Logout();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

    }
}