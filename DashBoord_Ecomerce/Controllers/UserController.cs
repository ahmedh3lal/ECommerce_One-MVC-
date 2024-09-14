using DashBoord_Ecomerce.IRepo.Base;
using DashBoord_Ecomerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace DashBoord_Ecomerce.Controllers
{
    public class UserController : Controller
    {
        protected IRepoBase<User> _repoBase;
        public UserController(IRepoBase<User> prod)
        {
            _repoBase = prod;
        }
        public async Task<IActionResult> Index()
        {
            var res = await _repoBase.GetAllAsync();
            return View(res);
        }
        public async Task<IActionResult> Update(int id)
        {
            var res = await _repoBase.GetByIdAsync(id);
            return View(res);
        }
        [HttpPost]
        public async Task<IActionResult> Update(User user)
        {
            if (user.formFile != null)
            {
                MemoryStream memoryStream = new MemoryStream();
                user.formFile.CopyTo(memoryStream);
                user.ImageBytes = memoryStream.ToArray();
            }
            await _repoBase.UpdateAsync(user);
            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> Delete(int id)
        {
            User user = await _repoBase.GetByIdAsync(id);
            await _repoBase.DeleteAsync(user);

            return RedirectToAction("Index");
        }

    }
}
