using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Fahrgemeinschaftsplattform.Models;
using System.Threading.Tasks;

namespace Fahrgemeinschaftsplattform.Controllers
{
    public class AccountController : Controller
    {
        // Instanzen von UserManager und SignInManager zum Verwalten von Benutzern und deren Anmeldestatus
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        // Konstruktor zur Injektion von UserManager und SignInManager
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET-Methode für das Registrierungsformular
        [HttpGet]
        public IActionResult Register() => View();

        // POST-Methode für die Registrierung
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            // Überprüfen, ob die Model-Daten gültig sind
            if (ModelState.IsValid)
            {
                // Erstellen eines neuen Benutzers mit den im Modell angegebenen Daten
                var user = new User { UserName = model.Email, Email = model.Email, Name = model.Name };
                var result = await _userManager.CreateAsync(user, model.Password);

                // Bei erfolgreicher Registrierung den Benutzer anmelden und Erfolgsnachricht anzeigen
                if (result.Succeeded)
                {
                    ViewData["SuccessMessage"] = "Die Registrierung war erfolgreich. Willkommen!";
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return View();
                }

                // Fehler anzeigen, falls die Registrierung fehlschlägt
                ViewData["ErrorMessage"] = "Registrierung fehlgeschlagen. Bitte überprüfen Sie Ihre Eingaben.";
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            // Rückgabe des Modells an die View, wenn die Registrierung nicht erfolgreich ist
            return View(model);
        }

        // GET-Methode für das Login-Formular
        [HttpGet]
        public IActionResult Login() => View();

        // POST-Methode für das Login
        [HttpPost]
        [ValidateAntiForgeryToken] // Schutz vor CSRF-Angriffen
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl; // Speichert die URL, zu der der Benutzer zurückkehren soll

            // Überprüfen, ob die Model-Daten gültig sind
            if (ModelState.IsValid)
            {
                // Versucht, den Benutzer mit den angegebenen Anmeldedaten anzumelden
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    // Wenn Anmeldung erfolgreich, Weiterleitung zur angegebenen URL oder zur Standardseite
                    return RedirectToLocal(returnUrl);
                }
            }
            // Wenn die Anmeldung fehlschlägt, Rückgabe des Modells an die View
            return View(model);
        }

        // Hilfsmethode zur lokalen Weiterleitung, falls die angegebene URL relativ zur Anwendung ist
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl)) // Überprüft, ob die URL lokal ist
            {
                return Redirect(returnUrl); // Weiterleitung zur Rückgabeseite
            }
            else
            {
                // Wenn keine gültige Rückgabeseite angegeben ist, Weiterleitung zur Startseite
                return RedirectToAction(nameof(HomeController.Index), "Routes");
            }
        }

        // POST-Methode für das Logout
        [HttpPost]
        [ValidateAntiForgeryToken] // Schutz vor CSRF-Angriffen
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync(); // Abmelden des Benutzers
            return RedirectToAction("Index", "Home"); // Weiterleitung zur Startseite nach dem Logout
        }
    }
}
