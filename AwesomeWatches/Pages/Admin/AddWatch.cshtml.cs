using AwesomeWatches.Data;
using AwesomeWatches.Models;
using AwesomeWatches.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AwesomeWatches.Pages.Admin;

public class AddWatchModel : PageModel
{
    [BindProperty()]
    public ItemViewModel ItemToAdd { get; set; }
    private readonly WatchesContext context;

    public ICollection<Category> Categories { get; set; }
    public AddWatchModel(WatchesContext injectedContext)
    {
        context = injectedContext;
        Categories = injectedContext.Categories.ToList();
    }
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var item = new Item
        {
            Price = ItemToAdd.Price,
            QuantityInStock = ItemToAdd.QuantityInStock
        };

        var product = new Product
        {
            Name = ItemToAdd.Name,
            Description = ItemToAdd.Description,
            Item = item
        };

        product.Categories =
            (from category in Categories
             join productCategory in ItemToAdd.CategoriesString.Split(",")
             on category.Id.ToString() equals productCategory
             select category).ToList();

        context.Products.Add(product);
        context.SaveChanges();

        AddImageToStorage(product);

        return RedirectToPage("Index");
    }

    private void AddImageToStorage(Product product)
    {
        var filePath = Path.Combine(
            Directory.GetCurrentDirectory(),
            "wwwroot",
            "Assets",
            "Images",
            "watches_pics",
            product.Id.ToString() + ".png");

        if (ItemToAdd.Picture?.Length > 0)
        {
            using (var fileStram = new FileStream(filePath, FileMode.Create))
            {
                ItemToAdd.Picture.CopyTo(fileStram);
            }
        }
    }

    public void OnGet()
    {
    }
}

