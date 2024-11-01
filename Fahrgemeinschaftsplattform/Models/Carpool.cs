namespace Fahrgemeinschaftsplattform.Models
{
    public class Carpool
    {
        public int Id { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public List<User> Users { get; set; } = new List<User>();
    }
}
