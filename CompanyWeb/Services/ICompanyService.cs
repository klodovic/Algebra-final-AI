using CompanyWeb.ModelDTO;

namespace CompanyWeb.Services
{
    public interface ICompanyService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(int id, string token);
        Task<T> CreateAsync<T>(OrganizationCreateDTO entity, string token);
        Task<T> UpdateAsync<T>(OrganizationDTO entity, string token);
        Task<T> DeleteAsync<T>(int id, string token);
    }
}
