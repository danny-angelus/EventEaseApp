namespace EventEaseApp.Models;

/// <summary>
/// Represents an attendance record for an event
/// </summary>
public class AttendanceRecord
{
    public int Id { get; set; }
    public int EventId { get; set; }
    public string EventName { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime RegistrationDate { get; set; }
    public string AttendanceStatus { get; set; } = "Registered"; // Registered, Confirmed, Attended, Cancelled
    public int NumberOfAttendees { get; set; } = 1;
}
