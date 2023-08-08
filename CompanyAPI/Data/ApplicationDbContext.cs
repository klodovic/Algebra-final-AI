using CompanyAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace CompanyAPI.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<LocalUser> LocalUsers { get; set; }
        public DbSet<Organization> Organizations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organization>().HasData(
                new Organization
                {
                    Id = 1,
                    CompanyName = "AB Gradnja",
                    Street = "Ilica 12",
                    City = "Zagreb",
                    PostNumber = "1000",
                    Country = "Hrvatska",
                    Phone = "01/888555",
                    Fax = "01/888555",
                    CellNumber = "098/888555",
                    Website = "www/ab.hr",
                    Email = "info@ab.hr",
                    Oib = "123456",
                    Mbs = "012345648",
                    Iban = "HR012345678998787121",
                    CreatedTime = DateTime.Now
                },
                new Organization
                {
                    Id = 2,
                    CompanyName = "CD Gradnja",
                    Street = "Ilica 152",
                    City = "Zagreb",
                    PostNumber = "10000",
                    Country = "Hrvatska",
                    Phone = "01/999252",
                    Fax = "01/999252",
                    CellNumber = "098/999252",
                    Website = "www/cd.hr",
                    Email = "info@cd.hr",
                    Oib = "1234564587",
                    Mbs = "01234564897",
                    Iban = "HR0123456789264581",
                    CreatedTime = DateTime.Now
                },
                new Organization
                {
                    Id = 3,
                    CompanyName = "Adria",
                    Street = "Selska ulica 15",
                    City = "Zagreb",
                    PostNumber = "10000",
                    Country = "Hrvatska",
                    Phone = "01/2255663",
                    Fax = "01/2255663",
                    CellNumber = "098/2255663",
                    Website = "www/adria.hr",
                    Email = "info@2255663.hr",
                    Oib = "9874563210",
                    Mbs = "9876543210",
                    Iban = "HR012345676543210",
                    CreatedTime = DateTime.Now
                }
                );
        }
    }
}
