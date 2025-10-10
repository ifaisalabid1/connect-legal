using System.ComponentModel.DataAnnotations;

namespace ConnectLegal.DTOs;

public class LawyerDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string About { get; set; } = string.Empty;
    public string? Website { get; set; }
    public string? Phone { get; set; }
    public string Email { get; set; } = string.Empty;
    public bool IsFeatured { get; set; } = false;
    public int YearOfExperience { get; set; } = 0;
    public Guid LawFirmId { get; set; }
    public LawFirmDto LawFirm { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
}

public class CreateLawyerDto
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
    public int YearOfExperience { get; set; } = 0;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}

public class UpdateLawyerDto
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
    public int YearOfExperience { get; set; } = 0;
    public DateTime? UpdatedAt { get; set; } = DateTime.Now;
}