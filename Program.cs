using Ghiman_Antonia_Lab2.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Ghiman_Antonia_Lab2Context") ?? throw new InvalidOperationException("Connection string 'Ghiman_Antonia_Lab2Context' not found.");

builder.Services.AddDbContext<Ghiman_Antonia_Lab2Context>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddRazorPages();

builder.Services.AddDbContext<LibraryIdentityContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<Ghiman_Antonia_Lab2.Data.ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<LibraryIdentityContext>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();