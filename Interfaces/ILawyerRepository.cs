using ConnectLegal.Entities;

namespace ConnectLegal.Interfaces;

public interface ILawyerRepository : IRepository<Lawyer>
{
    Task<IEnumerable<Lawyer>?> GetLawyersByLawFirmAsync(Guid lawFirmId);
    Task<Lawyer?> GetByEmailAsync(string email);
    Task<IEnumerable<Lawyer>?> GetFeaturedAsync();
    Task<Lawyer?> GetByIdWithLawFirmAsync(Guid id);
}