using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce_One.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Users")]
        public int User_ID {  get; set; }
        public Users Users { get; set; }
        
        [ForeignKey("Product")]
        public int Product_ID { get; set; }
        public Product Product {  get; set; }
        public int Quentity { get; set; }
        [ForeignKey("Payment")]
        public int Pay_ID { get; set; }
        public Payment Payment { get; set; }
        public double Total { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;

    }
}
