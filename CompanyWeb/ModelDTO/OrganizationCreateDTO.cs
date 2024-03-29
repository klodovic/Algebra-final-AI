﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CompanyWeb.ModelDTO
{
    public class OrganizationCreateDTO
    {
        [Required(ErrorMessage = "Ovo polje je obavezno")]
        [JsonPropertyName("company_name")]
        public string CompanyName { get; set; }

        [JsonPropertyName("street")]
        public string Street { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("postNumber")]
        public string PostNumber { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("fax")]
        public string Fax { get; set; }

        [JsonPropertyName("cellNumber")]
        public string CellNumber { get; set; }

        [JsonPropertyName("website")]
        public string Website { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("oib")]
        public string Oib { get; set; }

        [JsonPropertyName("mbs")]
        public string Mbs { get; set; }

        [JsonPropertyName("iban")]
        public string Iban { get; set; }
    }


    public class OrganizationDTO : OrganizationCreateDTO
    {
        [Required]
        public int Id { get; set; }

    }
}
