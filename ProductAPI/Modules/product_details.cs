using System.ComponentModel.DataAnnotations;
using System.Formats.Asn1;

namespace ProductAPI.Modules
{
    public class product_details
    {
        [Key()]
        public int product_id { get; set; }
        public Guid product_code { get; set; }
        public int product_category_code { get; set; }
        [Required]
        public string product_name { get; set; }
        [Required]
        public string product_company { get; set; }
        public string? product_description { get; set; }
        [Required]
        public DateTime created_on { get; set; }

    }
}
