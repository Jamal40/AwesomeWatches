using AwesomeWatches.Data;
using AwesomeWatches.Models;
using AwesomeWatches.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AwesomeWatches.Controllers;


public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private static readonly Cart _cart = new Cart();
    private readonly WatchesContext db;
    public HomeController(WatchesContext InjectedContext,
        ILogger<HomeController> logger)
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
        ViewData["Title"] = "Main";
        AssignCartItemCountToViewData();
        var protducts = db.Products.ToList<Product>();
        return View(protducts);
    }

    public IActionResult Details(int id)
    {
        ViewData["Title"] = "Details";
        int itemId = id;
        var product = db.Products
            .Include(p => p.Item)
            .Include(p => p.Categories)
            .FirstOrDefault(p => p.ItemId == itemId);

        if (product != null)
        {
            return View(product);
        }
        else
        {
            return RedirectToAction("Index");
        }
    }

    public IActionResult ShowCart()
    {
        ViewData["Title"] = "Cart";
        var cartVM = new CartViewModel
        {
            CartItems = _cart.CartItems,
            OrderTotal = _cart.CartItems
            .Sum(i => i.GetTotalPrice())
        };
        AssignCartItemCountToViewData();
        return View(cartVM);
    }

    public IActionResult AddToCart(int id)
    {
        int itemId = id;
        var product = db.Products
            .Include(p => p.Item)
            .FirstOrDefault(p => p.ItemId == itemId);

        if (product != null)
        {
            var cartItem = new CartItem
            {
                Item = product.Item,
                Quantity = 1
            };
            _cart.AddItem(cartItem);
        }
        return RedirectToAction(nameof(ShowCart));
    }

    public IActionResult Privacy()
    {
        AssignCartItemCountToViewData();
        return View();
    }

    [ResponseCache(Duration = 0,
        Location = ResponseCacheLocation.None,
        NoStore = true)]
    public IActionResult Error()
    {
        return View(new { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

