using Microsoft.AspNetCore.Mvc;
using PoliceAbsenceService.Application.DTOs;
using PoliceAbsenceService.Application.Services;

namespace PoliceAbsenceService.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AbsenceDeclarationsController : ControllerBase
{
    private readonly IAbsenceDeclarationService _service;

    public AbsenceDeclarationsController(IAbsenceDeclarationService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateDeclaration([FromBody] CreateAbsenceDeclarationRequest request)
    {
        var result = await _service.CreateDeclarationAsync(request);

        if (!result.IsSuccess)
            return BadRequest(new { error = result.Error });

        return Created();
    }
    /*
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<AbsenceDeclarationResponse>> GetDeclaration(Guid id)
    {
        var result = await _service.GetDeclarationAsync(id);

        if (!result.IsSuccess)
            return NotFound(new { error = result.Error });

        return Ok(result.Value);
    }

    [HttpPost("{id:guid}/approve")]
    [Authorize(Roles = "PoliceOfficer,Admin")]
    public async Task<ActionResult> ApproveDeclaration(Guid id)
    {
        var approvedBy = User.Identity.Name;
        var result = await _service.ApproveDeclarationAsync(id, approvedBy);

        if (!result.IsSuccess)
            return BadRequest(new { error = result.Error });

        return NoContent();
    }
    */
}
