using RoadsOfRussiaWeb.Entities;

namespace RoadsOfRussiaWeb.Models
{
    public class EventResponse
    {
        public int Id { get; set; }

        public string NameEvent { get; set; } = null!;

        public string TypeEvent { get; set; }
        public int IdTypeEvent { get; set; }

        public string StatusEvent { get; set; }

        public DateTime DateTimeEvent { get; set; }

        public string Description { get; set; } = null!;
        public string? NameEmployee { get; set; }
        public string? Email { get; set; }

        public EventResponse(Event events)
        {
            Id = events.Id;
            NameEvent = events.NameEvent;
            TypeEvent = events.IdTypeEventNavigation.Title;
            IdTypeEvent = events.IdTypeEvent;
            NameEmployee = events.IdEmployeeNavigation?.Name;
            Email = events.IdEmployeeNavigation?.Email;
            StatusEvent = events.IdStatusEventNavigation.Title;
            DateTimeEvent = events.DateTimeEvent;
            Description = events.Description;
        }
    }
}
