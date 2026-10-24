using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ghiman_Antonia_Lab2.Models;

namespace Ghiman_Antonia_Lab2.Pages.Categories;

public class DetailsModel : PageModel
{
    private readonly Ghiman_Antonia_Lab2Context _context;
    public DetailsModel(Ghiman_Antonia_Lab2Context context)
    {
        _context = context;
    }

    public Category Category { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var Category = await _context.Category.FirstOrDefaultAsync(m => m.ID == id);
        if (Category is null)
        {
            return NotFound();
        }
        else
        {
            Category = Category;
        }

        return Page();
    }
}
