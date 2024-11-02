namespace Fahrgemeinschaftsplattform.Models
{
    // Modell zur Darstellung der Daten, die beim Login-Formular verwendet werden
    public class LoginViewModel
    {
        // E-Mail-Adresse des Benutzers, die zur Anmeldung verwendet wird
        public string Email { get; set; }

        // Passwort des Benutzers zur Authentifizierung
        public string Password { get; set; }

        // Option, um den Benutzer angemeldet zu halten (z. B. durch ein persistentes Cookie)
        public bool RememberMe { get; set; }
    }
}
