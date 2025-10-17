using ConnectLegal.DTOs;
using ConnectLegal.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConnectLegal.Controllers;

[ApiController]
[Route("api/lawyers")]
public class LawyerController(ILawyerService lawyerService) : ControllerBase
{
    private readonly ILawyerService _lawyerService = lawyerService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LawyerResponseDto>>> GetLawyers()
    {
        var lawyers = await _lawyerService.GetAllLawyersAsync();
        return Ok(lawyers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LawyerResponseDto>> GetLawyer(Guid id)
    {
        var lawyer = await _lawyerService.GetLawyerByIdAsync(id);

        if (lawyer is null)
            return NotFound();

        return Ok(lawyer);
    }

    [HttpGet("law-firm/{lawFirmId}")]
    public async Task<ActionResult<IEnumerable<LawyerResponseDto>>> GetLawyersByLawFirm(Guid lawFirmId)
    {
        var lawyers = await _lawyerService.GetLawyersByLawFirmAsync(lawFirmId);
        return Ok(lawyers);
    }

    [HttpPost]
    public async Task<ActionResult<LawyerResponseDto>> CreateLawyer(CreateLawyerDto createLawyerDto)
    {
        try
        {
            var createdLawyer = await _lawyerService.CreateLawyerAsync(createLawyerDto);
            return CreatedAtAction(nameof(GetLawyer), new { id = createdLawyer.Id }, createdLawyer);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { error = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateLawyer(Guid id, UpdateLawyerDto updateLawyerDto)
    {
        try
        {
            await _lawyerService.UpdateLawyerAsync(id, updateLawyerDto);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLawyer(Guid id)
    {
        try
        {
            await _lawyerService.DeleteLawyerAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}
