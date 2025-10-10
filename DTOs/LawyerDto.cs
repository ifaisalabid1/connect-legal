using System.ComponentModel.DataAnnotations;

namespace ConnectLegal.DTOs;

public class LawyerDto
{
    [Key]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Name is required."), MaxLength(255, ErrorMessage = "Name must not be more than 255 characters long.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "About is required."), MaxLength(500, ErrorMessage = "Name must not be more than 500 characters long.")]
    public string About { get; set; } = string.Empty;

    [Url(ErrorMessage = "Website must be a proper url."), MaxLength(255, ErrorMessage = "Name must not be more than 255 characters long.")]
    public string? Website { get; set; }

    [Phone(ErrorMessage = "Phone number is invalid.")]
    public string? Phone { get; set; }

    [Required(ErrorMessage = "Email is required."), EmailAddress(ErrorMessage = "Email address is invalid."), MaxLength(255, ErrorMessage = "Name must not be more than 255 characters long.")]
    public string Email { get; set; } = string.Empty;
    public bool IsFeatured { get; set; } = false;

    [Range(0, 100, ErrorMessage = "Year of Experience must be between 0 and 100.")]
    public int YearOfExperience { get; set; } = 0;
    public Guid LawFirmId { get; set; }
    public LawFirmDto LawFirm { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
}

public class CreateLawyerDto
{
    [Required(ErrorMessage = "Name is required."), MaxLength(255, ErrorMessage = "Name must not be more than 255 characters long.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "About is required."), MaxLength(500, ErrorMessage = "Name must not be more than 500 characters long.")]
    public string About { get; set; } = string.Empty;

    [Url(ErrorMessage = "Website must be a proper url."), MaxLength(255, ErrorMessage = "Name must not be more than 255 characters long.")]
    public string? Website { get; set; }

    [Phone(ErrorMessage = "Phone number is invalid.")]
    public string? Phone { get; set; }

    [Required(ErrorMessage = "Email is required."), EmailAddress(ErrorMessage = "Email address is invalid."), MaxLength(255, ErrorMessage = "Name must not be more than 255 characters long.")]
    public string Email { get; set; } = string.Empty;
    public bool IsFeatured { get; set; } = false;

    [Range(0, 100, ErrorMessage = "Year of Experience must be between 0 and 100.")]
    public int YearOfExperience { get; set; } = 0;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}

public class UpdateLawyerDto
{
    [Required(ErrorMessage = "Name is required."), MaxLength(255, ErrorMessage = "Name must not be more than 255 characters long.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "About is required."), MaxLength(500, ErrorMessage = "Name must not be more than 500 characters long.")]
    public string About { get; set; } = string.Empty;

    [Url(ErrorMessage = "Website must be a proper url."), MaxLength(255, ErrorMessage = "Name must not be more than 255 characters long.")]
    public string? Website { get; set; }

    [Phone(ErrorMessage = "Phone number is invalid.")]
    public string? Phone { get; set; }

    [Required(ErrorMessage = "Email is required."), EmailAddress(ErrorMessage = "Email address is invalid."), MaxLength(255, ErrorMessage = "Name must not be more than 255 characters long.")]
    public string Email { get; set; } = string.Empty;
    public bool IsFeatured { get; set; } = false;

    [Range(0, 100, ErrorMessage = "Year of Experience must be between 0 and 100.")]
    public int YearOfExperience { get; set; } = 0;
    public DateTime? UpdatedAt { get; set; } = DateTime.Now;
}