using AutoMapper;
using ConnectLegal.DTOs;
using ConnectLegal.Entities;
using ConnectLegal.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConnectLegal.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LawyersController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<LawyersController> logger) : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly ILogger<LawyersController> _logger = logger;


    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<LawyerDto>), 200)]
    public async Task<IActionResult> GetLawyers()
    {
        var lawyers = await _unitOfWork.Lawyers.GetAllAsync();
        var lawyersDto = _mapper.Map<IEnumerable<LawyerDto>>(lawyers);
        return Ok(lawyersDto);
    }


    [HttpGet("{id}")]
    [ProducesResponseType(typeof(LawyerDto), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetLawyer(Guid id)
    {
        var lawyer = await _unitOfWork.Lawyers.GetByIdAsync(id);
        if (lawyer == null)
        {
            _logger.LogWarning("GetLawyer({Id}) NOT FOUND", id);
            return NotFound();
        }
        var lawyerDto = _mapper.Map<LawyerDto>(lawyer);
        return Ok(lawyerDto);
    }


    [HttpPost]
    [ProducesResponseType(typeof(LawyerDto), 201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> PostLawyer(CreateLawyerDto createLawyerDto)
    {
        var lawyer = _mapper.Map<Lawyer>(createLawyerDto);
        await _unitOfWork.Lawyers.AddAsync(lawyer);
        await _unitOfWork.CompleteAsync();

        var lawyerDto = _mapper.Map<LawyerDto>(lawyer);
        return CreatedAtAction(nameof(GetLawyer), new { id = lawyerDto.Id }, lawyerDto);
    }


    [HttpPut("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> PutLawyer(Guid id, UpdateLawyerDto updateLawyerDto)
    {
        var lawyer = await _unitOfWork.Lawyers.GetByIdAsync(id);
        if (lawyer == null)
        {
            return NotFound();
        }

        _mapper.Map(updateLawyerDto, lawyer);
        _unitOfWork.Lawyers.UpdateAsync(lawyer);
        await _unitOfWork.CompleteAsync();

        return NoContent();
    }


    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteLawyer(Guid id)
    {
        var lawyer = await _unitOfWork.Lawyers.GetByIdAsync(id);
        if (lawyer == null)
        {
            return NotFound();
        }
        _unitOfWork.Lawyers.DeleteAsync(lawyer);
        await _unitOfWork.CompleteAsync();

        return NoContent();
    }
}