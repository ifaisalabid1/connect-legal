using ConnectLegal.Entities;

namespace ConnectLegal.Interfaces.Repositories;

public interface ILawFirmRepository : IBaseRepository<LawFirm>
{
    Task<LawFirm?> GetByEmailAsync(string email, CancellationToken cancellationToken);
    Task<IEnumerable<LawFirm>?> GetFeaturedAsync(CancellationToken cancellationToken);
}