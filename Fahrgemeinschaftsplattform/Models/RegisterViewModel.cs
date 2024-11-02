using System.ComponentModel.DataAnnotations;

namespace Fahrgemeinschaftsplattform.Models
{
    // Modell zur Darstellung der Daten, die beim Registrierungsformular verwendet werden
    public class RegisterViewModel
    {
        // Name des Benutzers, erforderlich für die Registrierung
        [Required]
        public string Name { get; set; }

        // E-Mail-Adresse des Benutzers, erforderlich und muss ein gültiges E-Mail-Format sein
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        // Passwort des Benutzers, erforderlich und als Passwortfeld im Formular angezeigt
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
