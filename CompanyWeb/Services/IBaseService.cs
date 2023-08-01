using AutoMapper.Internal;
using CompanyWeb.Model;
using CompanyWeb.Models;

namespace CompanyWeb.Services
{
    public interface IBaseService
    {
        ApiResponse responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
