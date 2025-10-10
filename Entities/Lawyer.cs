namespace ConnectLegal.Entities;

public class Lawyer
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string About { get; set; } = string.Empty;
    public string? Website { get; set; }
    public string? Phone { get; set; }
    public string Email { get; set; } = string.Empty;
    public string IsFeatured { get; set; } = string.Empty;
    public int YearOfExperience { get; set; }
    public Guid LawFirmId { get; set; }
    public virtual LawFirm LawFirm { get; set; } = null!;
}