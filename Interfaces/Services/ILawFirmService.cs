using ConnectLegal.DTOs;

namespace ConnectLegal.Interfaces.Services;

public interface ILawFirmService : IBaseService<LawFirmDto>
{
    Task<LawFirmDto?> GetByEmailAsync(string email);
    Task<IEnumerable<LawFirmDto>?> GetFeaturedAsync();
}