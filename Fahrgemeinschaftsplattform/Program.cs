using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Fahrgemeinschaftsplattform.Data;

var builder = WebApplication.CreateBuilder(args);

// Dienste hinzufügen
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication();
builder.Services.AddControllers();

var app = builder.Build();

app.UsePathBase("/myapp");
app.UseStaticFiles();

// Reihenfolge der Middleware-Aufrufe festlegen
app.UseRouting(); // Muss vor UseAuthentication, UseAuthorization und UseEndpoints stehen

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

app.Run();
