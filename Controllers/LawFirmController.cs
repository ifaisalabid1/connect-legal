using ConnectLegal.DTOs;
using ConnectLegal.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConnectLegal.Controllers;

[ApiController]
[Route("api/law-firms")]
[Authorize]
public class LawFirmController(ILawFirmService lawFirmService) : ControllerBase
{
    private readonly ILawFirmService _lawFirmService = lawFirmService;

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<LawFirmResponseDto>>> GetLawFirms()
    {
        var lawFirms = await _lawFirmService.GetAllLawFirmsAsync();
        return Ok(lawFirms);
    }


    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult<LawFirmResponseDto>> GetLawFirm(Guid id)
    {
        var lawFirm = await _lawFirmService.GetLawFirmByIdAsync(id);

        if (lawFirm is null)
            return NotFound();

        return Ok(lawFirm);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<LawFirmResponseDto>> CreateLawFirm(CreateLawFirmDto createLawFirmDto)
    {
        try

        {
            var createdLawFirm = await _lawFirmService.CreateLawFirmAsync(createLawFirmDto);
            return CreatedAtAction(nameof(GetLawFirm), new { id = createdLawFirm.Id }, createdLawFirm);
        }
        catch (Exception ex)

        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateLawFirm(Guid id, UpdateLawFirmDto updateLawFirmDto)
    {
        try
        {
            await _lawFirmService.UpdateLawFirmAsync(id, updateLawFirmDto);
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
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteLawFirm(Guid id)
    {
        try
        {
            await _lawFirmService.DeleteLawFirmAsync(id);
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
