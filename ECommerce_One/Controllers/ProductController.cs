using ECommerce_One.Context;
using ECommerce_One.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_One.Controllers
{
   
    public class ProductController : Controller
    {
        private AppDbContext _AppDbContext { get; set; }
        public ProductController(AppDbContext appDbContext)
        {
            _AppDbContext = appDbContext;
        }
        public IActionResult Index()
        {

            return View();
        }
        
       
    }
}
