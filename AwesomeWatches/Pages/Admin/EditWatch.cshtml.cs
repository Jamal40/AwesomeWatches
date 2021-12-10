using AwesomeWatches.Data;
using AwesomeWatches.Models;
using AwesomeWatches.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AwesomeWatches.Pages.Admin;

public class EditWatchModel : PageModel
{
    [BindProperty()]
    public ItemViewModel WatchToEdit { get; set; }
    public ICollection<Category> Categories { get; set; }
    public ICollection<Category> SelectedCategories { get; set; }
    private readonly WatchesContext context;

    public EditWatchModel(WatchesContext injectedContext)
    {
        context = injectedContext;
        Categories = context.Categories.ToList();
    }
    public IActionResult OnPost(int id)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToPage(new { Id = id });
        }
        var currentWatchProduct = context.Products
            .Include(p => p.Item)
            .Include(p => p.Categories)
            .FirstOrDefault(p => p.Id == id);

        if (currentWatchProduct is null)
        {
            return RedirectToPage("Index");
        }

        currentWatchProduct.Name = WatchToEdit.Name;
        currentWatchProduct.Description = WatchToEdit.Description;
        currentWatchProduct.Item.Price = WatchToEdit.Price;
        currentWatchProduct.Item.QuantityInStock = WatchToEdit.QuantityInStock;
        currentWatchProduct.Categories.Clear();
        currentWatchProduct.Categories =
            (from category in Categories
             join productCategory in WatchToEdit.CategoriesString.Split(",")
             on category.Id.ToString() equals productCategory
             select category).ToList();

        context.Entry(currentWatchProduct).State = EntityState.Modified;
        context.SaveChanges();

        AddImageToStorage();

        return RedirectToPage("Index");
    }
    public IActionResult OnGet(int id)
    {
        var currentProduct = context.Products
            .Include(p => p.Item)
            .Include(p => p.Categories)
            .FirstOrDefault(p => p.Id == id);

        if (currentProduct is null)
        {
            return RedirectToPage("Index");
        }

        WatchToEdit = new ItemViewModel
        {
            Id = currentProduct.Id,
            Name = currentProduct.Name,
            Description = currentProduct.Description,
            Price = currentProduct.Item.Price,
            QuantityInStock = currentProduct.Item.QuantityInStock,
            CategoriesString =
                string.Join(",", currentProduct.Categories.Select(c => c.Id)
                .ToList())
        };

        SelectedCategories = (ICollection<Category>)
            (currentProduct.Categories ?? Enumerable.Empty<Category>());

        return Page();
    }
    public string GetImageLocation()
    {
        return Path.Combine(
            Directory.GetCurrentDirectory(),
            "wwwroot",
            "Assets",
            "Images",
            "watches_pics",
            WatchToEdit.Id.ToString() + ".png");
    }
    private void AddImageToStorage()
    {
        var filePath = GetImageLocation();

        if (WatchToEdit.Picture?.Length > 0)
        {
            using (var fileStram = new FileStream(filePath, FileMode.Create))
            {
                WatchToEdit.Picture.CopyTo(fileStram);
            }
        }
    }

}

