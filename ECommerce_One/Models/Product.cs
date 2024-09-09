using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce_One.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Quentity { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string? Description { get; set; }
        
        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public byte[]? Image { get; set; }
        [NotMapped]
        public IFormFile? formFile;
       
        [NotMapped]
        public string? ImageUrl
        {
            get
            {
                if (Image != null)
                {
                    string base64 = Convert.ToBase64String(Image, 0, Image.Length);
                    return "data:image/png;base64," + base64;
                }
                return string.Empty;
            }
        }
        
        public Category? Category { get; set; }
    }
}
