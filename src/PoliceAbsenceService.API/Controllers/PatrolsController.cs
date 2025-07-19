using Microsoft.AspNetCore.Mvc;
using PoliceAbsenceService.Application.Services;

namespace PoliceAbsenceService.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatrolsController : ControllerBase
{
    private readonly IPatrolSchedulingService _patrolService;

    public PatrolsController(IPatrolSchedulingService patrolService)
    {
        _patrolService = patrolService;
    }

    /*
    [HttpGet("schedule")]
    public async Task<IActionResult> GetDailySchedule([FromQuery] DateTime? date = null)
    {
        var targetDate = date ?? DateTime.Today;
        var result = await _patrolService.GetPatrolScheduleAsync(targetDate);

        if (!result.IsSuccess)
            return BadRequest(new { error = result.Error });

        return Ok(result.Value);
    }

    [HttpPost("{id:guid}/complete")]
    public async Task<ActionResult> CompletePatrol(Guid id, [FromBody] CompletePatrolRequest request)
    {
        var result = await _patrolService.CompletePatrolAsync(id, request.Notes);

        if (!result.IsSuccess)
            return BadRequest(new { error = result.Error });

        return NoContent();
    }
    */
}
