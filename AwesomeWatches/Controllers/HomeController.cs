using AwesomeWatches.Models;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeWatches.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static readonly Cart _cart = new Cart();

        #region Helper Methods
        private void AssignCartItemCountToViewData()
        {
            var total = _cart.CartItems.Sum(cartItem => cartItem.Quantity);
            ViewData["Shopping Cart Quantity"] = total;
        }
        #endregion

        public IActionResult Index()
        {
            AssignCartItemCountToViewData();
            return View();
        }
    }
}
