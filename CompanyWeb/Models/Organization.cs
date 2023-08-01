using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyWeb.Models
{
    public class Organization
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostNumber { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string CellNumber { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string Oib { get; set; }
        public string Mbs { get; set; }
        public string Iban { get; set; }
        public DateTime CreatedTime { get; set; }


    }
}
