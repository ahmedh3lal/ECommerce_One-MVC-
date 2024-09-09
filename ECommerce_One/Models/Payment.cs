using System.ComponentModel.DataAnnotations;

namespace ECommerce_One.Models
{
    public class Payment
    {
        [Key]
        public int ID { get; set; }
        [Required]  
        public string Name { get; set; }
    }
}
