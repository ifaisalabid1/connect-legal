using AutoMapper;
using ConnectLegal.DTOs;
using ConnectLegal.Entities;
using ConnectLegal.Interfaces;
using ConnectLegal.Repositories;

namespace ConnectLegal.Services;

public class LawyerService(ILawyerRepository lawyerRepository, IMapper mapper) : ILawyerService
{
    private readonly ILawyerRepository _lawyerRepository = lawyerRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<LawyerResponseDto> CreateLawyerAsync(CreateLawyerDto createLawyerDto)
    {
        var lawyer = _mapper.Map<Lawyer>(createLawyerDto);

        var createdLawyer = await _lawyerRepository.AddAsync(lawyer);

        return _mapper.Map<LawyerResponseDto>(createdLawyer);
    }

    public async Task DeleteLawyerAsync(Guid id)
    {
        var lawFirm = await _lawyerRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"Law Firm with id {id} not found.");

        await _lawyerRepository.DeleteAsync(lawFirm);
    }

    public async Task<IEnumerable<LawyerResponseDto>> GetAllLawyersAsync()
    {
        var lawFirms = await _lawyerRepository.GetAllAsync();

        return _mapper.Map<IEnumerable<LawyerResponseDto>>(lawFirms);
    }

    public async Task<LawyerResponseDto?> GetLawyerByIdAsync(Guid id)
    {
        var lawFirm = await _lawyerRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"Law Firm with id {id} not found.");

        return _mapper.Map<LawyerResponseDto>(lawFirm);
    }

    public async Task<IEnumerable<LawyerResponseDto>?> GetLawyersByLawFirmAsync(Guid lawFirmId)
    {
        var lawyers = await _lawyerRepository.GetLawyersByLawFirmAsync(lawFirmId);

        return _mapper.Map<IEnumerable<LawyerResponseDto>>(lawyers);
    }

    public async Task UpdateLawyerAsync(Guid id, UpdateLawyerDto updateLawyerDto)
    {
        var existingLawyer = await _lawyerRepository.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"Lawyer with ID {id} not found.");

        _mapper.Map(updateLawyerDto, existingLawyer);
        existingLawyer.UpdatedAt = DateTime.Now;

        await _lawyerRepository.UpdateAsync(existingLawyer);
    }
}