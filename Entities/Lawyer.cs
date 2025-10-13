namespace ConnectLegal.Entities;

public class Lawyer : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string About { get; set; } = string.Empty;
    public string? Website { get; set; }
    public string? Phone { get; set; }
    public string Email { get; set; } = string.Empty;
    public bool IsFeatured { get; set; } = false;
    public int YearOfExperience { get; set; } = 0;
    public Guid? LawFirmId { get; set; }
    public virtual LawFirm? LawFirm { get; set; } = null!;
}