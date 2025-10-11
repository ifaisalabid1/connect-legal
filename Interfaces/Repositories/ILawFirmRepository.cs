using ConnectLegal.Entities;

namespace ConnectLegal.Interfaces.Repositories;

public interface ILawFirmRepository : IBaseRepository<LawFirm>
{
    Task<LawFirm?> GetByEmailAsync(string email);
    Task<IEnumerable<LawFirm>?> GetFeaturedAsync();
}