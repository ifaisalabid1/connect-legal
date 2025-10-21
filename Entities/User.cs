using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ConnectLegal.Entities;

public class User : IdentityUser
{
    [Required, MaxLength(255)]
    public required string FirstName { get; set; }

    [Required, MaxLength(255)]
    public required string LastName { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    public bool IsActive { get; set; } = true;
}