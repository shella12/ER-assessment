using System.ComponentModel.DataAnnotations;

namespace CrmScreening.Models;

// Task 1 — C# Model
public class Customer
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Full Name is required.")]
    [Display(Name = "Full Name")]
    public string FullName { get; set; } = string.Empty;

    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    public string Email { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    [Display(Name = "Created At")]
    public DateTime CreatedAt { get; set; }

    [Display(Name = "Active")]
    public bool IsActive { get; set; } = true;

    // Returns a single formatted string containing all the customer's key details.
    public string GetSummary()
    {
        var status = IsActive ? "Active" : "Inactive";
        return $"#{Id} — {FullName} | {Email} | {Phone} | Created {CreatedAt:yyyy-MM-dd} | {status}";
    }
}
