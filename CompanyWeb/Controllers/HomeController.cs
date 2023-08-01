using CompanyWeb.Models;
using CompanyWeb.ModelDTO;
using CompanyWeb.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CompanyWeb.Model;
using CompanyAPI.ModelDTO;
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
                identity.AddClaim(new Claim(ClaimTypes.Email, model.User.Email));
                identity.AddClaim(new Claim(ClaimTypes.Role, model.User.Role)); //array of roles
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme ,principal);

                HttpContext.Session.SetString(StaticDetails.SessionToken, model.Token);
                return RedirectToAction("Index", "Company");
            }
            else
            {
                ModelState.AddModelError("CustomError", response.ErrorMessage.FirstOrDefault());
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
        public async Task<IActionResult> Register(RegisterUserDTO obj)
        {
            ApiResponse result = await _authService.RegisterAsync<ApiResponse>(obj);
            if (result != null && result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View();
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

    }
}