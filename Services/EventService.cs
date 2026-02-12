using EventEaseApp.Models;

namespace EventEaseApp.Services;

/// <summary>
/// Service to manage events (with mock data)
/// </summary>
public class EventService
{
    private readonly List<Event> _events;

    public EventService()
    {
        // Mock event data
        _events = new List<Event>
        {
            new Event
            {
                Id = 1,
                Name = "Technology Conference 2026",
                Date = new DateTime(2026, 3, 15, 9, 0, 0),
                Location = "Convention Center, Mexico City",
                Description = "The most important annual technology conference in Latin America. International experts will share the latest trends in AI, Cloud Computing and Web Development.",
                Capacity = 500
            },
            new Event
            {
                Id = 2,
                Name = "Charity Gala",
                Date = new DateTime(2026, 4, 20, 19, 0, 0),
                Location = "Marriott Hotel, Guadalajara",
                Description = "Elegant evening to raise funds for educational programs for children in vulnerable communities.",
                Capacity = 200
            },
            new Event
            {
                Id = 3,
                Name = "Electronic Music Festival",
                Date = new DateTime(2026, 5, 10, 18, 0, 0),
                Location = "Fundidora Park, Monterrey",
                Description = "The most anticipated festival of the year with the best international and national DJs. Three stages and more than 12 hours of music.",
                Capacity = 5000
            },
            new Event
            {
                Id = 4,
                Name = "UX/UI Design Workshop",
                Date = new DateTime(2026, 3, 25, 10, 0, 0),
                Location = "Coworking Space, Puebla",
                Description = "Intensive user experience and interface design workshop. Learn agile methodologies and modern design tools.",
                Capacity = 30
            },
            new Event
            {
                Id = 5,
                Name = "Entrepreneurs Expo",
                Date = new DateTime(2026, 6, 5, 8, 0, 0),
                Location = "World Trade Center, Mexico City",
                Description = "Startup and entrepreneur exhibition. Networking, keynote speakers and investment opportunities.",
                Capacity = 1000
            },
            new Event
            {
                Id = 6,
                Name = "E-Sports Tournament",
                Date = new DateTime(2026, 7, 12, 14, 0, 0),
                Location = "Gaming Arena, Querétaro",
                Description = "National video game competition with cash prizes. Tournaments of League of Legends, Valorant and CS:GO.",
                Capacity = 300
            }
        };
    }

    /// <summary>
    /// Gets all available events
    /// </summary>
    public List<Event> GetAllEvents()
    {
        return _events.OrderBy(e => e.Date).ToList();
    }

    /// <summary>
    /// Gets an event by its ID
    /// </summary>
    public Event? GetEventById(int id)
    {
        return _events.FirstOrDefault(e => e.Id == id);
    }

    /// <summary>
    /// Gets upcoming events (from today onwards)
    /// </summary>
    public List<Event> GetUpcomingEvents()
    {
        return _events
            .Where(e => e.Date >= DateTime.Now)
            .OrderBy(e => e.Date)
            .ToList();
    }

    /// <summary>
    /// Generates a large dataset of events for performance testing
    /// </summary>
    public List<Event> GenerateLargeDataset(int count = 100)
    {
        var largeDataset = new List<Event>(_events);
        var random = new Random();
        var eventTypes = new[]
        {
            "Conference", "Workshop", "Meetup", "Festival", "Expo",
            "Seminar", "Webinar", "Concert", "Tournament", "Gala"
        };
        var locations = new[]
        {
            "Convention Center", "Hotel Ballroom", "Tech Hub", "Park",
            "Stadium", "Arena", "Auditorium", "Theater", "Plaza"
        };
        var cities = new[]
        {
            "Mexico City", "Guadalajara", "Monterrey", "Puebla",
            "Querétaro", "Tijuana", "León", "Cancún"
        };

        for (int i = 7; i <= count; i++)
        {
            var eventType = eventTypes[random.Next(eventTypes.Length)];
            var location = locations[random.Next(locations.Length)];
            var city = cities[random.Next(cities.Length)];
            
            largeDataset.Add(new Event
            {
                Id = i,
                Name = $"{eventType} {i}",
                Date = DateTime.Now.AddDays(random.Next(1, 365)).AddHours(random.Next(8, 20)),
                Location = $"{location}, {city}",
                Description = $"Join us for this amazing {eventType.ToLower()} event with networking opportunities and learning experiences.",
                Capacity = random.Next(50, 1000)
            });
        }

        return largeDataset.OrderBy(e => e.Date).ToList();
    }
}
