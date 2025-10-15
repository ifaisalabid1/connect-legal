using AutoMapper;
using ConnectLegal.DTOs;
using ConnectLegal.Entities;
using ConnectLegal.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConnectLegal.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LawFirmsController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<LawFirmsController> logger) : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly ILogger<LawFirmsController> _logger = logger;


    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<LawFirmDto>), 200)]
    public async Task<IActionResult> GetLawFirms()
    {
        var lawFirms = await _unitOfWork.LawFirms.GetAllAsync();
        var lawFirmsDto = _mapper.Map<IEnumerable<LawFirmDto>>(lawFirms);
        return Ok(lawFirmsDto);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(LawyerDto), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetLawyer(Guid id)
    {
        var lawFirm = await _unitOfWork.LawFirms.GetByIdAsync(id);
        if (lawFirm == null)
        {
            _logger.LogWarning("GetLawFirm({Id}) NOT FOUND", id);
            return NotFound();
        }
        var lawFirmDto = _mapper.Map<LawyerDto>(lawFirm);
        return Ok(lawFirmDto);
    }

    [HttpPost]
    [ProducesResponseType(typeof(LawFirmDto), 201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> PostLawFirm(CreateLawFirmDto createLawFirmDto)
    {
        var lawFirm = _mapper.Map<LawFirm>(createLawFirmDto);
        await _unitOfWork.LawFirms.AddAsync(lawFirm);
        await _unitOfWork.CompleteAsync();

        var lawFirmDto = _mapper.Map<LawFirmDto>(lawFirm);
        return CreatedAtAction(nameof(GetLawFirms), new { id = lawFirmDto.Id }, lawFirmDto);
    }


    [HttpPut("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> PutLawFirm(Guid id, UpdateLawFirmDto updateLawFirmDto)
    {
        var lawFirm = await _unitOfWork.LawFirms.GetByIdAsync(id);
        if (lawFirm == null)
        {
            return NotFound();
        }

        _mapper.Map(updateLawFirmDto, lawFirm);
        _unitOfWork.LawFirms.UpdateAsync(lawFirm);
        await _unitOfWork.CompleteAsync();

        return NoContent();
    }


    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteLawFirm(Guid id)
    {
        var lawFirm = await _unitOfWork.LawFirms.GetByIdAsync(id);
        if (lawFirm == null)
        {
            return NotFound();
        }

        _unitOfWork.LawFirms.DeleteAsync(lawFirm);
        await _unitOfWork.CompleteAsync();

        return NoContent();
    }
}