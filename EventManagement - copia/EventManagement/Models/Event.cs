namespace EventManagement.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty; // Asegúrate de inicializar con un valor por defecto
        public string Description { get; set; } = string.Empty; // Asegúrate de inicializar con un valor por defecto
        public DateTime EventDate { get; set; }
        public string Location { get; set; } = string.Empty; // Asegúrate de inicializar con un valor por defecto
    }
}
