namespace ConnectLegal.Entities;

public class LawFirm
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string About { get; set; } = string.Empty;
    public string Website { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public string Email { get; set; } = string.Empty;
    public string IsFeatured { get; set; } = string.Empty;
    public virtual ICollection<Lawyer> Lawyers { get; set; } = [];
}