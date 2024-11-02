using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Fahrgemeinschaftsplattform.Data;
using Fahrgemeinschaftsplattform.Models;
using Fahrgemeinschaftsplattform.Services;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

var cultureInfo = new CultureInfo("en-US");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

// Dienste hinzufügen

// Konfiguration des DbContext zur Verwendung von SQL Server und Laden der Verbindungszeichenfolge aus der Konfigurationsdatei
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Konfiguration von Identity für die Benutzer- und Rollenverwaltung
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequireDigit = false; // Keine Ziffer im Passwort erforderlich
    options.Password.RequiredLength = 4; // Mindestlänge des Passworts auf 4 Zeichen festgelegt
    options.Password.RequireNonAlphanumeric = false; // Keine Sonderzeichen im Passwort erforderlich
    options.Password.RequireUppercase = false; // Keine Großbuchstaben im Passwort erforderlich
    options.Password.RequireLowercase = false; // Keine Kleinbuchstaben im Passwort erforderlich
})
.AddEntityFrameworkStores<ApplicationDbContext>() // Verwendung von Entity Framework zum Speichern von Benutzerdaten
.AddDefaultTokenProviders(); // Standard-Token-Provider für die Generierung von Sicherheits-Tokens

// Hinzufügen des MVC-Controllers und der View-Dienste
builder.Services.AddControllersWithViews();

// Registrierung des CarpoolService für Dependency Injection
builder.Services.AddScoped<CarpoolService>();

// Hinzufügen von Authentifizierungs- und Autorisierungsdiensten
builder.Services.AddAuthorization();
builder.Services.AddAuthentication();
builder.Services.AddControllers();

builder.Services.AddSingleton<RouteService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        context.Database.Migrate();
        context.Seed(); // Dummy-Datensätze laden
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}

// Basis-URL für die App festlegen
app.UsePathBase("/myapp");

// Middleware für statische Dateien aktivieren
app.UseStaticFiles();

// Reihenfolge der Middleware-Aufrufe festlegen
app.UseRouting(); // Muss vor UseAuthentication, UseAuthorization und UseEndpoints stehen

// Authentifizierungsmiddleware aktivieren
app.UseAuthentication();

// Autorisierungsmiddleware aktivieren
app.UseAuthorization();

// Routing konfigurieren und Standard-Controller-Route definieren
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

// Anwendung ausführen
app.Run();
