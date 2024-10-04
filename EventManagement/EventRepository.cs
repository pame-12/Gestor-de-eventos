using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace EventManagement.Repositories // Asegúrate de que esto coincida con tu espacio de nombres
{
    public class EventRepository
    {
        private readonly string connectionString;

        public EventRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddEvent(Event newEvent)
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();
            var command = new MySqlCommand("INSERT INTO Events (Title, Description, EventDate, Location) VALUES (@Title, @Description, @EventDate, @Location)", connection);
            command.Parameters.AddWithValue("@Title", newEvent.Title);
            command.Parameters.AddWithValue("@Description", newEvent.Description);
            command.Parameters.AddWithValue("@EventDate", newEvent.EventDate);
            command.Parameters.AddWithValue("@Location", newEvent.Location);
            command.ExecuteNonQuery();
        }

        public List<Event> GetAllEvents()
        {
            var events = new List<Event>();
            using var connection = new MySqlConnection(connectionString);
            connection.Open();
            var command = new MySqlCommand("SELECT * FROM Events", connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                events.Add(new Event
                {
                    Id = reader.GetInt32("Id"),
                    Title = reader.GetString("Title"),
                    Description = reader.GetString("Description"),
                    EventDate = reader.GetDateTime("EventDate"),
                    Location = reader.GetString("Location")
                });
            }
            return events;
        }

        public void UpdateEvent(Event updatedEvent)
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();
            var command = new MySqlCommand("UPDATE Events SET Title=@Title, Description=@Description, EventDate=@EventDate, Location=@Location WHERE Id=@Id", connection);
            command.Parameters.AddWithValue("@Id", updatedEvent.Id);
            command.Parameters.AddWithValue("@Title", updatedEvent.Title);
            command.Parameters.AddWithValue("@Description", updatedEvent.Description);
            command.Parameters.AddWithValue("@EventDate", updatedEvent.EventDate);
            command.Parameters.AddWithValue("@Location", updatedEvent.Location);
            command.ExecuteNonQuery();
        }

        public void DeleteEvent(int id)
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();
            var command = new MySqlCommand("DELETE FROM Events WHERE Id=@Id", connection);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
        }
    }
}
