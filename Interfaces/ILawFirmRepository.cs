using ConnectLegal.Entities;

namespace ConnectLegal.Interfaces;

public interface ILawFirmRepository : IRepository<LawFirm>
{
    Task<LawFirm?> GetByEmailAsync(string email);
    Task<IEnumerable<LawFirm>?> GetFeaturedAsync();
    Task<bool> LawFirmExistsAsync(Guid id);
}