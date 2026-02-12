using EventEaseApp.Models;
using Microsoft.JSInterop;
using System.Text.Json;

namespace EventEaseApp.Services;

/// <summary>
/// Service to manage user sessions with localStorage persistence
/// </summary>
public class UserSessionService
{
    private readonly IJSRuntime _jsRuntime;
    private UserSession? _currentSession;
    private const string SessionKey = "eventease_user_session";

    public event Action? OnSessionChanged;

    public UserSessionService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    /// <summary>
    /// Initialize and load session from localStorage
    /// </summary>
    public async Task InitializeAsync()
    {
        try
        {
            var sessionJson = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", SessionKey);
            if (!string.IsNullOrEmpty(sessionJson))
            {
                _currentSession = JsonSerializer.Deserialize<UserSession>(sessionJson);
            }
        }
        catch
        {
            _currentSession = null;
        }
    }

    /// <summary>
    /// Login user and create session
    /// </summary>
    public async Task LoginUserAsync(string userName, string email)
    {
        _currentSession = new UserSession
        {
            UserId = Guid.NewGuid().ToString(),
            UserName = userName,
            Email = email,
            SessionStart = DateTime.Now,
            IsLoggedIn = true
        };

        await SaveSessionAsync();
        OnSessionChanged?.Invoke();
    }

    /// <summary>
    /// Logout user and clear session
    /// </summary>
    public async Task LogoutUserAsync()
    {
        _currentSession = null;
        try
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", SessionKey);
        }
        catch { }
        
        OnSessionChanged?.Invoke();
    }

    /// <summary>
    /// Get current user session
    /// </summary>
    public UserSession? GetCurrentUser()
    {
        return _currentSession;
    }

    /// <summary>
    /// Check if user is logged in
    /// </summary>
    public bool IsLoggedIn()
    {
        return _currentSession?.IsLoggedIn ?? false;
    }

    /// <summary>
    /// Save session to localStorage
    /// </summary>
    private async Task SaveSessionAsync()
    {
        if (_currentSession != null)
        {
            try
            {
                var sessionJson = JsonSerializer.Serialize(_currentSession);
                await _jsRuntime.InvokeVoidAsync("localStorage.setItem", SessionKey, sessionJson);
            }
            catch { }
        }
    }
}
