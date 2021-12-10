using AwesomeWatches.Data;
using AwesomeWatches.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AwesomeWatches.Pages.Admin;

public class CategoryModel : PageModel
{
    private readonly WatchesContext context;

    [BindProperty()]
    public Category RequiredCategory { get; set; }

    public CategoryModel(WatchesContext injectedContext)
    {
        context = injectedContext;
    }
    public IActionResult OnPost(int? id)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        if (id is not null)
        {
            RequiredCategory.Id = id.Value;
            context.Entry(RequiredCategory).State = EntityState.Modified;
        }

        if (id is null)
        {
            context.Categories.Add(RequiredCategory);
        }

        context.SaveChanges();
        return RedirectToPage("Index");
    }
    public void OnGet(int? id)
    {
        if (id is not null)
        {
            RequiredCategory = context.Categories.Find(id);
        }
    }
}

