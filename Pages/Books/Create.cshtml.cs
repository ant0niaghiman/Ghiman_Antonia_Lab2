using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ghiman_Antonia_Lab2.Models;

namespace Ghiman_Antonia_Lab2.Pages.Books;

public class CreateModel : PageModel
{
    private readonly Ghiman_Antonia_Lab2Context _context;

    public CreateModel(Ghiman_Antonia_Lab2Context context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        ViewData["AuthorID"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Author, "ID", "LastName");
        ViewData["PublisherID"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Publisher, "ID", "PublisherName");
        return Page();
    }

    [BindProperty]
    public Book Book { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Book.Add(Book);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
