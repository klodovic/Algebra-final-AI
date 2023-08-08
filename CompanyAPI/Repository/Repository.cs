using CompanyAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace CompanyAPI.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public readonly ApplicationDbContext _db;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int? id)
        {
            if (id.Equals(null))
            {
                return null;
            }
            return await _db.Set<T>().FindAsync(id);
        }

        public async Task CreateAsync(T entity)
        {
            await _db.AddAsync(entity);
            await SaveAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _db.Remove(entity);
            await SaveAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _db.Update(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public bool IsCompanyUnique(string company)
        {
            var org = _db.Organizations.FirstOrDefault(x => x.CompanyName == company);
            if (org == null)
            {
                return true;
            }
            return false;
        }
    }
}
