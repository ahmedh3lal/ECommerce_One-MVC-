
using ECommerce_One.Context;
using ECommerce_One.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace ECommerce_One.Controllers
{
    public class UserController : Controller
    {
        
        private AppDbContext _AppDbContext { get; set; }
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _Environment;
        public UserController(AppDbContext appDbContext,Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment) 
        {
            _AppDbContext = appDbContext;    
            _Environment= hostingEnvironment;   
       
        }
        public IActionResult Index(int id)
        {
            Users res = _AppDbContext.users.FirstOrDefault(u => u.Id == id);
            
            return View(res);
        }
        public IActionResult LOGIN()
        {
            return View();
        }
        [HttpPost]
         public IActionResult LOGIN(Users? users)
        {
            var res = _AppDbContext.users.FirstOrDefault((u => u.Email == users.Email));
            if(res== null)
            {
                ModelState.AddModelError("cust Error", "Error tray agin invalid username or password");
                return View();
            }
            if(res.Password!=users.Password)
            {
                ModelState.AddModelError("cust Error","Error tray agin invalid username or password");
                return View();
            }
            int id=res.Id;
            return RedirectToAction("Index","User", new {id});
        }
          public IActionResult Register()
        {
            return View();
        }
        [HttpPost]  
          public IActionResult Register(Users users)
        {
            if(users.formFile!=null)
            {
                MemoryStream memoryStream = new MemoryStream(); 
                users.formFile.CopyTo(memoryStream);
                users.ImageBytes =memoryStream.ToArray();
            }
            if (!ModelState.IsValid||users.Password!=users.Re_Password)
            {
               
                ModelState.AddModelError("cus Error", "Pass not Equal RePassword");
                return View();
            }

               _AppDbContext.users.Add(users);
                _AppDbContext.SaveChanges();
           
            return RedirectToAction("LOGIN");
        }
        public IActionResult Update(int id)
        {
            var res = _AppDbContext.users.FirstOrDefault(u=>u.Id==id);
            return View(res);
        }
        [HttpPost]
          public IActionResult Update(Users users)
        {
            if (users.formFile != null)
            {
                MemoryStream memoryStream = new MemoryStream();
                users.formFile.CopyTo(memoryStream);
                users.ImageBytes = memoryStream.ToArray();
            }
            if(users.Password!=users.Re_Password)
            {
                ModelState.AddModelError("cus Error", "Pass not Equal RePassword");
                return View();
            }
           
            _AppDbContext.users.Update(users);
            _AppDbContext.SaveChanges();
            return RedirectToAction("Index", "User",new { users.Id });
        }
        
        
    }
}
