using EventEaseApp.Models;

namespace EventEaseApp.Services;

/// <summary>
/// Service to manage event attendance tracking
/// </summary>
public class AttendanceService
{
    private readonly List<AttendanceRecord> _attendanceRecords = new();
    private int _nextId = 1;

    public event Action? OnAttendanceChanged;

    /// <summary>
    /// Register attendance for an event
    /// </summary>
    public AttendanceRecord RegisterAttendance(int eventId, string eventName, UserSession user, int numberOfAttendees = 1)
    {
        var record = new AttendanceRecord
        {
            Id = _nextId++,
            EventId = eventId,
            EventName = eventName,
            UserId = user.UserId,
            UserName = user.UserName,
            Email = user.Email,
            RegistrationDate = DateTime.Now,
            AttendanceStatus = "Registered",
            NumberOfAttendees = numberOfAttendees
        };

        _attendanceRecords.Add(record);
        OnAttendanceChanged?.Invoke();
        return record;
    }

    /// <summary>
    /// Get all attendance records for a specific user
    /// </summary>
    public List<AttendanceRecord> GetUserAttendance(string userId)
    {
        return _attendanceRecords
            .Where(a => a.UserId == userId)
            .OrderByDescending(a => a.RegistrationDate)
            .ToList();
    }

    /// <summary>
    /// Get all attendees for a specific event
    /// </summary>
    public List<AttendanceRecord> GetEventAttendees(int eventId)
    {
        return _attendanceRecords
            .Where(a => a.EventId == eventId)
            .OrderBy(a => a.UserName)
            .ToList();
    }

    /// <summary>
    /// Get attendance statistics for an event
    /// </summary>
    public (int TotalRegistrations, int TotalAttendees, Dictionary<string, int> StatusCounts) GetEventStatistics(int eventId)
    {
        var eventRecords = _attendanceRecords.Where(a => a.EventId == eventId).ToList();
        
        var totalRegistrations = eventRecords.Count;
        var totalAttendees = eventRecords.Sum(a => a.NumberOfAttendees);
        var statusCounts = eventRecords
            .GroupBy(a => a.AttendanceStatus)
            .ToDictionary(g => g.Key, g => g.Count());

        return (totalRegistrations, totalAttendees, statusCounts);
    }

    /// <summary>
    /// Get all attendance records
    /// </summary>
    public List<AttendanceRecord> GetAllAttendance()
    {
        return _attendanceRecords.OrderByDescending(a => a.RegistrationDate).ToList();
    }

    /// <summary>
    /// Check if user is registered for an event
    /// </summary>
    public bool IsUserRegistered(int eventId, string userId)
    {
        return _attendanceRecords.Any(a => a.EventId == eventId && a.UserId == userId);
    }

    /// <summary>
    /// Cancel attendance
    /// </summary>
    public bool CancelAttendance(int recordId)
    {
        var record = _attendanceRecords.FirstOrDefault(a => a.Id == recordId);
        if (record != null)
        {
            record.AttendanceStatus = "Cancelled";
            OnAttendanceChanged?.Invoke();
            return true;
        }
        return false;
    }
}
