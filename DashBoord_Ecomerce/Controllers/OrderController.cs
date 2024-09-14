using DashBoord_Ecomerce.IRepo.Base;
using DashBoord_Ecomerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace DashBoord_Ecomerce.Controllers
{
    public class OrderController : Controller
    {
        protected IRepoBase<Order> _repoBase;
        public OrderController(IRepoBase<Order> prod)
        {
            _repoBase = prod;
        }
        public async Task<IActionResult> Index()
        {
            var res = await _repoBase.GetAllAsync();
            return View(res);
        }
    }
}
