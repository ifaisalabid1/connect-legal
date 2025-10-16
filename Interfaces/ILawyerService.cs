using ConnectLegal.DTOs;

namespace ConnectLegal.Interfaces;

public interface ILawyerService
{
    Task<IEnumerable<LawyerResponseDto>> GetAllLawyersAsync();
    Task<LawyerResponseDto?> GetLawyerByIdAsync(Guid id);
    Task<LawyerResponseDto> CreateLawyerAsync(CreateLawyerDto createLawyerDto);
    Task UpdateLawyerAsync(Guid id, UpdateLawyerDto updateLawyerDto);
    Task DeleteLawyerAsync(Guid id);
    Task<IEnumerable<LawyerResponseDto>?> GetLawyersByLawFirmAsync(Guid lawFirmId);
}