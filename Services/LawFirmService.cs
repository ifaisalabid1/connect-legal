using AutoMapper;
using ConnectLegal.DTOs;
using ConnectLegal.Entities;
using ConnectLegal.Interfaces;
using ConnectLegal.Repositories;

namespace ConnectLegal.Services;

public class LawFirmService(ILawFirmRepository lawFirmRepository, IMapper mapper) : ILawFirmService
{
    private readonly ILawFirmRepository _lawFirmRepository = lawFirmRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<LawFirmResponseDto> CreateLawFirmAsync(CreateLawFirmDto createLawFirmDto)
    {
        var lawFirm = _mapper.Map<LawFirm>(createLawFirmDto);

        var createdLawFirm = await _lawFirmRepository.AddAsync(lawFirm);

        return _mapper.Map<LawFirmResponseDto>(createdLawFirm);
    }

    public async Task DeleteLawFirmAsync(Guid id)
    {
        var lawFirm = await _lawFirmRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"Law Firm with id {id} not found.");

        await _lawFirmRepository.DeleteAsync(lawFirm);
    }

    public async Task<IEnumerable<LawFirmResponseDto>> GetAllLawFirmsAsync()
    {
        var lawFirms = await _lawFirmRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<LawFirmResponseDto>>(lawFirms);
    }

    public async Task<LawFirmDetailDto?> GetLawFirmByIdAsync(Guid id)
    {
        var lawFirm = await _lawFirmRepository.GetByIdWithLawyersAsync(id);
        return _mapper.Map<LawFirmDetailDto>(lawFirm);
    }

    public async Task UpdateLawFirmAsync(Guid id, UpdateLawFirmDto updateLawFirmDto)
    {
        var existingLawFirm = await _lawFirmRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"Law Firm with id {id} not found.");

        _mapper.Map(updateLawFirmDto, existingLawFirm);

        existingLawFirm.UpdatedAt = DateTime.Now;

        await _lawFirmRepository.UpdateAsync(existingLawFirm);
    }
}