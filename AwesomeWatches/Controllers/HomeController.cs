using AwesomeWatches.Data;
using AwesomeWatches.Models;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeWatches.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static readonly Cart _cart = new Cart();
        private readonly WatchesContext db;
        public HomeController(WatchesContext InjectedContext, ILogger<HomeController> logger)
        {
            _logger = logger;
            db = InjectedContext;
        }


        #region Helper Methods
        private void AssignCartItemCountToViewData()
        {
            var total = _cart.CartItems.Sum(cartItem => cartItem.Quantity);
            ViewData["Shopping Cart Quantity"] = total;
        }
        #endregion

        public IActionResult Index()
        {
            var protducts = db.Products.ToList<Product>();
            return View(protducts);
        }
        public IActionResult Details()
        {
            return View();
        }
    }
}
