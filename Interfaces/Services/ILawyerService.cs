using ConnectLegal.DTOs;

namespace ConnectLegal.Interfaces.Services;

public interface ILawyerService : IBaseService<LawyerDto>
{
    Task<LawyerDto?> GetByEmailAsync(string email);
    Task<IEnumerable<LawyerDto>?> GetFeaturedAsync();
}