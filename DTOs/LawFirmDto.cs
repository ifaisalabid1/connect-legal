using System.ComponentModel.DataAnnotations;

namespace ConnectLegal.DTOs;

public class LawFirmDto
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
    public List<LawyerDto> Lawyers { get; set; } = [];
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
}

public class CreateLawFirmDto
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
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}

public class UpdateLawFirmDto
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
    public DateTime? UpdatedAt { get; set; } = DateTime.Now;
}