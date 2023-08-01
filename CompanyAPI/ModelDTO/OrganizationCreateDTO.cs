using System.ComponentModel.DataAnnotations;

namespace CompanyAPI.ModelDTO
{
    public class OrganizationCreateDTO
    {
        public string? CompanyName { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? PostNumber { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }
        public string? CellNumber { get; set; }
        public string? Website { get; set; }
        public string? Email { get; set; }
        public string? Oib { get; set; }
        public string? Mbs { get; set; }
        public string? Iban { get; set; }
        public DateTime CreatedTime { get; set; }
    }


    public class OrganizationDTO : OrganizationCreateDTO
    {
        [Required]
        public int Id { get; set; }

    }
}
