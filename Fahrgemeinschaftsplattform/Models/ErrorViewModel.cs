namespace Fahrgemeinschaftsplattform.Models
{
    // Modell zur Darstellung von Fehlerinformationen
    public class ErrorViewModel
    {
        // RequestId repräsentiert die ID der aktuellen Anfrage und kann zur Fehlerdiagnose genutzt werden
        public string? RequestId { get; set; }

        // ShowRequestId gibt an, ob die RequestId angezeigt werden soll (true, wenn die RequestId nicht leer ist)
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
