using AwesomeWatches.Data;
using AwesomeWatches.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AwesomeWatches.Pages.Admin;

public class AddCategoryModel : PageModel
{
    private readonly WatchesContext context;

    [BindProperty()]
    public Category CategoryToAdd { get; set; }

    public AddCategoryModel(WatchesContext injectedContext)
    {
        context = injectedContext;
    }
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        context.Categories.Add(CategoryToAdd);
        context.SaveChanges();

        return RedirectToPage("Index");
    }
    public void OnGet()
    {
    }
}

