using System.ComponentModel.DataAnnotations;

namespace ConnectLegal.DTOs;

public class LawFirmDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string About { get; set; } = string.Empty;
    public string? Website { get; set; }
    public string? Phone { get; set; }
    public string Email { get; set; } = string.Empty;
    public bool IsFeatured { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
}

public class CreateLawFirmDto
{
    [Required, MaxLength(255)]
    public string Name { get; set; } = string.Empty;

    [Required, MaxLength(500)]
    public string About { get; set; } = string.Empty;

    [Url, MaxLength(255)]
    public string? Website { get; set; }

    [Phone]
    public string? Phone { get; set; }

    [Required, EmailAddress, MaxLength(255)]
    public string Email { get; set; } = string.Empty;
    public bool IsFeatured { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}

public class UpdateLawFirmDto
{
    [Required, MaxLength(255)]
    public string Name { get; set; } = string.Empty;

    [Required, MaxLength(500)]
    public string About { get; set; } = string.Empty;

    [Url, MaxLength(255)]
    public string? Website { get; set; }

    [Phone]
    public string? Phone { get; set; }

    [Required, EmailAddress, MaxLength(255)]
    public string Email { get; set; } = string.Empty;
    public bool IsFeatured { get; set; } = false;
    public DateTime? UpdatedAt { get; set; } = DateTime.Now;
}