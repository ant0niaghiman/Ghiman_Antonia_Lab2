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

    public IList<Category> Category { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Category = await _context.Category.ToListAsync();
    }
}
