namespace ConnectLegal.Entities;

public class LawFirm : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string About { get; set; } = string.Empty;
    public string? Website { get; set; }
    public string? Phone { get; set; }
    public string Email { get; set; } = string.Empty;
    public bool IsFeatured { get; set; } = false;
    public virtual ICollection<Lawyer> Lawyers { get; set; } = [];
}