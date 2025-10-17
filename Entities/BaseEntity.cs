using System.ComponentModel.DataAnnotations;

namespace ConnectLegal.Entities;

public class BaseEntity
{
    [Key]
    public Guid Id { get; set; }
    public required DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
}