using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Fahrgemeinschaftsplattform.Models;
using System.Threading.Tasks;

namespace Fahrgemeinschaftsplattform.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    ViewData["SuccessMessage"] = "Die Registrierung war erfolgreich. Willkommen!";
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return View();
                }

                // Fehlermeldungen anzeigen, falls die Registrierung fehlschlägt
                ViewData["ErrorMessage"] = "Registrierung fehlgeschlagen. Bitte überprüfen Sie Ihre Eingaben.";
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }



        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                // Fehlermeldung setzen, wenn der Login fehlschlägt
                ViewData["ErrorMessage"] = "Login fehlgeschlagen. Bitte überprüfen Sie Ihre Anmeldedaten.";
            }

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
