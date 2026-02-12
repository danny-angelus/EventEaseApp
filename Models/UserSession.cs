namespace EventEaseApp.Models;

/// <summary>
/// Represents a user session in the application
/// </summary>
public class UserSession
{
    public string UserId { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime SessionStart { get; set; }
    public bool IsLoggedIn { get; set; }
}
