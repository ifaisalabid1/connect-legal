using AutoMapper;
using ConnectLegal.DTOs;
using ConnectLegal.Interfaces.Repositories;
using ConnectLegal.Interfaces.Services;

namespace ConnectLegal.Services;

public class LawFirmService(ILawFirmRepository lawFirmRepository, IMapper mapper) : ILawFirmService
{
    private readonly ILawFirmRepository _lawFirmRepository = lawFirmRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<CreateLawFirmDto> CreateLawFirmAsync(CreateLawFirmDto createLawFirmDto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteLawFirmAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _lawFirmRepository.DeleteAsync(id, cancellationToken);
    }

    public async Task<IEnumerable<LawFirmDto>> GetAllLawFirmsAsync(CancellationToken cancellationToken)
    {
        var lawFirms = await _lawFirmRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<LawFirmDto>>(lawFirms);
    }

    public async Task<IEnumerable<LawFirmDto>?> GetFeaturedAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<LawFirmDto?> GetLawFirmByEmailAsync(string email, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<LawFirmDto?> GetLawFirmByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var lawFirm = await _lawFirmRepository.GetByIdAsync(id, cancellationToken);
        return _mapper.Map<LawFirmDto?>(lawFirm);
    }

    public async Task<bool> LawFirmExistsAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _lawFirmRepository.ExistsAsync(id, cancellationToken);
    }

    public async Task<UpdateLawFirmDto?> UpdateLawFirmAsync(Guid id, UpdateLawFirmDto updateLawFirmDto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}