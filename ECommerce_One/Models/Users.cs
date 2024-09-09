using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce_One.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^\d{7}$", ErrorMessage = "Enter 7 Number ")]
        public string Password { get; set; }
        [Required]
        public string Re_Password { get; set; }
        [Required(ErrorMessage = "Enter Your Phone Number")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Enter 11 Number ")]
        public string Number { get; set; }
        [NotMapped]
        public IFormFile? formFile { get; set; }
        public byte[]? ImageBytes { get; set; }
        [NotMapped]
        public string ImageUrl
        {
            get
            {
                if(ImageBytes != null)
                {
                    string base64=Convert.ToBase64String(ImageBytes,0,ImageBytes.Length);
                    return "data:image/png;base64,"+base64;
                }
                return string.Empty;
            }
        }
        
    }
}
