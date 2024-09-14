using DashBoord_Ecomerce.IRepo.Base;
using DashBoord_Ecomerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace DashBoord_Ecomerce.Controllers
{
    public class PaymentController : Controller
    {
        protected IRepoBase<Payment> _repoBase;
        public PaymentController(IRepoBase<Payment> prod)
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
        public async Task<IActionResult> Create(Payment pay)
        {

            await _repoBase.CreateAsync(pay);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            var res = await _repoBase.GetByIdAsync(id);
            return View(res);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Payment pay)
        {

            await _repoBase.UpdateAsync(pay);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            Payment pay = await _repoBase.GetByIdAsync(id);
            await _repoBase.DeleteAsync(pay);

            return RedirectToAction("Index");
        }
    }
}
