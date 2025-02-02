﻿using ECommerce_One.Context;
using ECommerce_One.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ECommerce_One.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private AppDbContext _context { get; set; }

        public HomeController(ILogger<HomeController> logger, AppDbContext _context)
        {
            _logger = logger;
            this._context=_context;
        }

        public IActionResult Index()
        {
            var categories = _context.categories
                         .Include(c => c.Products)
                         .ToList();
            return View(categories);
            
        }

        public IActionResult Details(int id)
        {
            return View(_context.products.FirstOrDefault(x=>x.Id==id));
        }
           public IActionResult Category(int id)
        {
            var res= _context.products.Where(x=>x.CategoryID == id).ToList();
            return View(res);
        }
        public IActionResult Buy(int id)
        {
            var res = _context.payments.ToList();
            ViewData["Payment"] = res;
            return View(_context.products.FirstOrDefault(x => x.Id == id));
        }
        [HttpPost]
        public IActionResult Buy(Product product, string PaymentOption, int id)
        {
            var currentProduct = _context.products.FirstOrDefault(x => x.Id == id);

           
            int currentQuantity = currentProduct.Quentity;

            if (currentQuantity < product.Quentity)
            {
                ModelState.AddModelError("Cust", "not valid quentity");

                var paymentOptions = _context.payments.ToList();
                ViewData["Payment"] = paymentOptions;
                product=currentProduct;
                return View(product);
            }

            if (ModelState.IsValid)
            {

                currentProduct.Quentity -= product.Quentity;
                double quen =(double)(product.Quentity);
                double pr =(double)(product.Price);
                _context.products.FirstOrDefault(x => x.Id == id).Quentity = currentProduct.Quentity;
                var order = new Order
                {
                    Quentity = product.Quentity,
                    Product_ID = product.Id,
                    Pay_ID = int.Parse(PaymentOption),
                    User_ID = int.Parse(HttpContext.Session.GetString("SessionUserId")),
                    Total=quen*pr,
                    
                };

                _context.orders.Add(order);
                _context.SaveChanges();


                return RedirectToAction("Index");
            }
            return View(id);
        }
        public IActionResult Services()
        {
            
            return View();
        }
        public IActionResult Contact()
        {
            
            return View();
        }
         public IActionResult About()
        {
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
