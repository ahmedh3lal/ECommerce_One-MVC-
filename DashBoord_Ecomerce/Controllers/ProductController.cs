using DashBoord_Ecomerce.IRepo.Base;
using DashBoord_Ecomerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace DashBoord_Ecomerce.Controllers
{
    public class ProductController : Controller
    {
        protected IRepoBase<Product> _repoBase;
        public ProductController(IRepoBase<Product>prod)
        {
            _repoBase = prod;   
        }
        public async Task<IActionResult> Index()
        {
            var res = await _repoBase.GetAllAsync();
            return View(res);
        }
        public  IActionResult Create()
        {

            return  View();
        }
        [HttpPost]
         public async Task<IActionResult> Create(Product product)
        {
            if (product.formFile != null)
            {
                MemoryStream memoryStream = new MemoryStream();
                product.formFile.CopyTo(memoryStream);
                product.Image = memoryStream.ToArray();
            }
            await _repoBase.CreateAsync(product);
           return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            var res=await _repoBase.GetByIdAsync(id);
            return View(res);
        }
        [HttpPost]
        public async Task <IActionResult> Update(Product product)
        {
            if (product.formFile != null)
            {
                MemoryStream memoryStream = new MemoryStream();
                product.formFile.CopyTo(memoryStream);
                product.Image = memoryStream.ToArray();
            }
            await _repoBase.UpdateAsync(product);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(int id)
        {
            return View(await _repoBase.GetByIdAsync(id));
        }
           public async Task<IActionResult> Delete(int id)
        {
            Product product = await _repoBase.GetByIdAsync(id);
            await _repoBase.DeleteAsync(product);

            return RedirectToAction("Index");
        }

    }
}
