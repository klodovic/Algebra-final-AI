using AutoMapper;
using CompanyWeb.Model;
using CompanyWeb.ModelDTO;
using CompanyWeb.Services;
using CompanyWeb.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace CompanyWeb.Controllers
{
    public class CompanyController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICompanyService _companyService;

        public CompanyController(IMapper mapper, ICompanyService companyService)
        {
            _mapper = mapper;
            _companyService = companyService;
        }



        //Display all organizations
        public async Task<IActionResult> Index(string token)
        {
            List<OrganizationDTO> organizations = new();

            var response = await _companyService.GetAllAsync<ApiResponse>(HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (response != null && response.IsSuccess)
            {
                organizations = JsonConvert.DeserializeObject<List<OrganizationDTO>>(Convert.ToString(response.Result));
            }
            return View(organizations);
        }


        //Create new organization
        public async Task<IActionResult> Create(string token)
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
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);
        }



        //Update organization
        public async Task<IActionResult> Update(int id, string token)
        {
            var response = await _companyService.GetAsync<ApiResponse>(id, HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (response != null && response.IsSuccess)
            {
                OrganizationDTO model = JsonConvert.DeserializeObject<OrganizationDTO>(Convert.ToString(response.Result));
                return View(_mapper.Map<OrganizationDTO>(model));
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(OrganizationDTO model, string token)
        {
            if (ModelState.IsValid)
            {
                var response = await _companyService.UpdateAsync<ApiResponse>(model, HttpContext.Session.GetString(StaticDetails.SessionToken));
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);
        }


        //Delete organization
        public async Task<IActionResult> Delete(int id, string token)
        {
            var response = await _companyService.GetAsync<ApiResponse>(id, HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (response != null && response.IsSuccess)
            {
                OrganizationDTO model = JsonConvert.DeserializeObject<OrganizationDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(OrganizationDTO model, string token)
        {
            var response = await _companyService.DeleteAsync<ApiResponse>(model.Id, HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }


        //View organization
        public async Task<IActionResult> Details(int id, string token)
        {
            var response = await _companyService.GetAsync<ApiResponse>(id, HttpContext.Session.GetString(StaticDetails.SessionToken));
            if (response != null && response.IsSuccess)
            {
                OrganizationDTO model = JsonConvert.DeserializeObject<OrganizationDTO>(Convert.ToString(response.Result));
                return View(_mapper.Map<OrganizationDTO>(model));
            }
            return NotFound();
        }


    }
}
