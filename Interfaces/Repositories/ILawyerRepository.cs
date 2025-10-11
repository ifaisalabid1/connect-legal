using ConnectLegal.Entities;

namespace ConnectLegal.Interfaces.Repositories;

public interface ILawyerRepository : IBaseRepository<Lawyer>
{
    Task<Lawyer?> GetByEmailAsync(string email);
    Task<IEnumerable<Lawyer>?> GetFeaturedAsync();
}