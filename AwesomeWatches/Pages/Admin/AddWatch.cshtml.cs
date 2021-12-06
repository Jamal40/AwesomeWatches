using AwesomeWatches.Data;
using AwesomeWatches.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AwesomeWatches.Pages.Admin;

public class AddWatchModel : PageModel
{
    private readonly WatchesContext context;

    public ICollection<Category> Categories { get; set; }
    public AddWatchModel(WatchesContext injectedContext)
    {
        context = injectedContext;
        Categories = injectedContext.Categories.ToList();
    }
    public void OnGet()
    {
    }
}

