using System.ComponentModel.DataAnnotations;

namespace EventEaseApp.Models;

/// <summary>
/// Model for event registration form with validation
/// </summary>
public class RegistrationModel
{
    [Required(ErrorMessage = "Full name is required")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters")]
    [Display(Name = "Full Name")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email address is required")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address")]
    [StringLength(150, ErrorMessage = "Email cannot exceed 150 characters")]
    [Display(Name = "Email Address")]
    public string Email { get; set; } = string.Empty;

    [Phone(ErrorMessage = "Please enter a valid phone number")]
    [StringLength(20, ErrorMessage = "Phone number cannot exceed 20 characters")]
    [Display(Name = "Phone Number")]
    public string? Phone { get; set; }

    [Required(ErrorMessage = "Number of attendees is required")]
    [Range(1, 10, ErrorMessage = "Number of attendees must be between 1 and 10")]
    [Display(Name = "Number of Attendees")]
    public int NumberOfAttendees { get; set; } = 1;

    [StringLength(500, ErrorMessage = "Comments cannot exceed 500 characters")]
    [Display(Name = "Additional Comments")]
    public string? Comments { get; set; }
}
