using Ghiman_Antonia_Lab2.Models;
using Microsoft.EntityFrameworkCore;

public class Ghiman_Antonia_Lab2Context(DbContextOptions<Ghiman_Antonia_Lab2Context> options) : DbContext(options)
{
    public DbSet<Ghiman_Antonia_Lab2.Models.Book> Book { get; set; } = default!;
    public DbSet<Ghiman_Antonia_Lab2.Models.Publisher> Publisher { get; set; } = default!;
    public DbSet<Ghiman_Antonia_Lab2.Models.Author> Author { get; set; } = default!;
    public DbSet<Ghiman_Antonia_Lab2.Models.Category> Category { get; set; } = default!;
}
