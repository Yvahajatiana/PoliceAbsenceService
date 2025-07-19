using PoliceAbsenceService.Application.DTOs;

namespace PoliceAbsenceService.Application.Services;

public interface IPatrolSchedulingService
{
    Task<Result> GeneratePatrolScheduleAsync(Guid declarationId, CancellationToken cancellationToken = default);

    /** 
     * Future methods can be uncommented and implemented as needed
    Task<Result<List<PatrolScheduleDto>>> GetPatrolScheduleAsync(DateTime date, CancellationToken cancellationToken = default);

    Task<Result> CompletePatrolAsync(Guid patrolId, string notes, CancellationToken cancellationToken = default);
    */
}
