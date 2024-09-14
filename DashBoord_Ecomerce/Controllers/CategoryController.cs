using DashBoord_Ecomerce.IRepo.Base;
using DashBoord_Ecomerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace DashBoord_Ecomerce.Controllers
{
    public class CategoryController : Controller
    {
        protected IRepoBase<Category> _repoBase;
        public CategoryController(IRepoBase<Category> prod)
        {
            _repoBase = prod;
        }
        public async Task<IActionResult> Index()
        {
            var res = await _repoBase.GetAllAsync();
            return View(res);
        }
        public async Task<IActionResult> Create()
        {

            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category categ)
        {
            
            await _repoBase.CreateAsync(categ);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            var res = await _repoBase.GetByIdAsync(id);
            return View(res);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Category categ)
        {
           
            await _repoBase.UpdateAsync(categ);
            return RedirectToAction("Index");
        }
       
        public async Task<IActionResult> Delete(int id)
        {
            Category categ = await _repoBase.GetByIdAsync(id);
            await _repoBase.DeleteAsync(categ);

            return RedirectToAction("Index");
        }
    }
}
