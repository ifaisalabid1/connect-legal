using ConnectLegal.DTOs;

namespace ConnectLegal.Interfaces;

public interface ILawFirmService
{
    Task<IEnumerable<LawFirmResponseDto>> GetAllLawFirmsAsync();
    Task<LawFirmDetailDto?> GetLawFirmByIdAsync(Guid id);
    Task<LawFirmResponseDto> CreateLawFirmAsync(CreateLawFirmDto createLawFirmDto);
    Task UpdateLawFirmAsync(Guid id, UpdateLawFirmDto updateLawFirmDto);
    Task DeleteLawFirmAsync(Guid id);
}