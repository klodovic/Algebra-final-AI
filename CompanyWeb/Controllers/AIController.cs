using AutoMapper;
using CompanyWeb.Model;
using CompanyWeb.ModelDTO;
using CompanyWeb.Services;
using CompanyWeb.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace CompanyWeb.Controllers
{
    public class AIController : Controller
    {

        private readonly IMapper _mapper;
        private readonly ICompanyService _companyService;
        private string url;

        public AIController(IMapper mapper, ICompanyService companyService, IConfiguration configuration)
        {
            _mapper = mapper;
            _companyService = companyService;
            url = configuration.GetValue<string>("ServiceUrls:AiUrl");
        }


        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile fileToUpload)
        {
            //if(ModelState.IsValid){}
            using var memoryStream = new MemoryStream();
            await fileToUpload.CopyToAsync(memoryStream);
            memoryStream.Position = 0;

            using var client = new HttpClient();

            var content = new MultipartFormDataContent
            {
                { new StreamContent(memoryStream), "image", fileToUpload.FileName }
            };

            var response = await client.PostAsync(url, content);

            // Optional: read the response from your flask server
            var responseContent = await response.Content.ReadAsStringAsync();
            var model = JsonSerializer.Deserialize<OrganizationCreateDTO>(responseContent);

            return View("Create", model);
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrganizationCreateDTO model, string token)
        {
            if (ModelState.IsValid)
            {
                var response = await _companyService.CreateAsync<ApiResponse>(model, HttpContext.Session.GetString(StaticDetails.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction("Index", "Company");
                }
            }
            return RedirectToAction("Index", "AI");
        }
    }
}
