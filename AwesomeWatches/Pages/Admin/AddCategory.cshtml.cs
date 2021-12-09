using AwesomeWatches.Data;
using AwesomeWatches.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AwesomeWatches.Pages.Admin;

public class AddCategoryModel : PageModel
{
    private readonly WatchesContext context;

    [BindProperty()]
    public Category Category { get; set; }

    public AddCategoryModel(WatchesContext injectedContext)
    {
        context = injectedContext;
    }
    public IActionResult OnPost()
    {
        context.Categories.Add(Category);
        context.SaveChanges();

        return RedirectToPage(nameof(IndexModel.Page));
    }
    public void OnGet()
    {
    }
}

