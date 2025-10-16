using System.ComponentModel.DataAnnotations;

namespace ConnectLegal.Entities;

public class LawFirm : BaseEntity
{
    [Required(ErrorMessage = "Name is required.")]
    [MaxLength(255, ErrorMessage = "Name must not be more than 255 characters long.")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "About is required.")]
    [MaxLength(500, ErrorMessage = "Name must not be more than 500 characters long.")]
    public required string About { get; set; }

    [Url(ErrorMessage = "Website must be a proper url.")]
    [MaxLength(255, ErrorMessage = "Name must not be more than 255 characters long.")]
    public string? Website { get; set; }

    [Phone(ErrorMessage = "Phone number is invalid.")]
    public string? Phone { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [MaxLength(255, ErrorMessage = "Name must not be more than 255 characters long.")]
    [EmailAddress(ErrorMessage = "Email address is invalid.")]
    public required string Email { get; set; }
    public bool IsFeatured { get; set; } = false;
    public virtual ICollection<Lawyer> Lawyers { get; set; } = [];
}