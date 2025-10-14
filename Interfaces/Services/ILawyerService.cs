using ConnectLegal.DTOs;

namespace ConnectLegal.Interfaces.Services;

public interface ILawyerService
{
    Task<LawyerDto?> GetLawyerByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<LawyerDto>> GetAllLawyersAsync(CancellationToken cancellationToken);
    Task<CreateLawyerDto> CreateLawyerAsync(CreateLawyerDto createLawyerDto, CancellationToken cancellationToken);
    Task<UpdateLawyerDto?> UpdateLawyerAsync(Guid id, UpdateLawyerDto updateLawyerDto, CancellationToken cancellationToken);
    Task<bool> DeleteLawyerAsync(Guid id, CancellationToken cancellationToken);
    Task<bool> LawyerExistsAsync(Guid id, CancellationToken cancellationToken);
    Task<LawyerDto?> GetLawyerByEmailAsync(string email, CancellationToken cancellationToken);
    Task<IEnumerable<LawyerDto>?> GetFeaturedAsync(CancellationToken cancellationToken);
}