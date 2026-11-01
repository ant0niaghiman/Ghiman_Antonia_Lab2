using Ghiman_Antonia_Lab2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ghiman_Antonia_Lab2.Models;

namespace Ghiman_Antonia_Lab2.Pages.Categories;

public class IndexModel : PageModel
{
    private readonly Ghiman_Antonia_Lab2Context _context;

    public IndexModel(Ghiman_Antonia_Lab2Context context)
    {
        _context = context;
        
    }
    public CategoryIndexData CategoryData { get; set; }
    public int CategoryID { get; set; }

    public IList<Category> Category { get; set; } = default!;

    public async Task OnGetAsync(int? id)
    {
        CategoryData = new CategoryIndexData();

        CategoryData.Categories = await _context.Category
            .Include(i => i.BookCategories)
                .ThenInclude(i => i.Book)
                    .ThenInclude(i => i.Author)
            .OrderBy(i => i.CategoryName)
            .ToListAsync();

        if (id != null)
        {
            CategoryID = id.Value;

            Models.Category category = CategoryData.Categories
                .Where(i => i.ID == id.Value).Single();

            CategoryData.Books = category.BookCategories.Select(s => s.Book);
        }
    }
}
