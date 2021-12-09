using AwesomeWatches.Data;
using AwesomeWatches.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AwesomeWatches.Pages.Admin;

public class IndexModel : PageModel
{
    public IEnumerable<Product> Products { get; set; }
    public IEnumerable<Category> Categories { get; set; }

    private readonly WatchesContext _context;

    public IndexModel(WatchesContext injectedContext)
    {
        _context = injectedContext;
    }
    public void OnGet()
    {
        Products = _context.Products.Include(p => p.Item).ToList();
        Categories = _context.Categories.ToList();
    }
}

