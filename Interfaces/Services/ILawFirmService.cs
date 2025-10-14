using ConnectLegal.DTOs;

namespace ConnectLegal.Interfaces.Services;

public interface ILawFirmService
{
    Task<LawFirmDto?> GetLawFirmByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<LawFirmDto>> GetAllLawFirmsAsync(CancellationToken cancellationToken);
    Task<CreateLawFirmDto> CreateLawFirmAsync(CreateLawFirmDto createLawFirmDto, CancellationToken cancellationToken);
    Task<UpdateLawFirmDto?> UpdateLawFirmAsync(Guid id, UpdateLawFirmDto updateLawFirmDto, CancellationToken cancellationToken);
    Task<bool> DeleteLawFirmAsync(Guid id, CancellationToken cancellationToken);
    Task<bool> LawFirmExistsAsync(Guid id, CancellationToken cancellationToken);
    Task<LawFirmDto?> GetLawFirmByEmailAsync(string email, CancellationToken cancellationToken);
    Task<IEnumerable<LawFirmDto>?> GetFeaturedAsync(CancellationToken cancellationToken);
}