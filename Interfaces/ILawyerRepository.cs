using ConnectLegal.Entities;

namespace ConnectLegal.Interfaces;

public interface ILawyerRepository : IRepository<Lawyer>
{
    Task<IEnumerable<Lawyer>> GetLawyersByLawFirmIdAsync(Guid lawFirmId);
    Task<Lawyer?> GetByEmailAsync(string email);
    Task<IEnumerable<Lawyer>?> GetFeaturedAsync();
    Task<bool> LawyerExistsAsync(Guid id);
}