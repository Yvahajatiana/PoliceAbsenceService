using PoliceAbsenceService.Domain.Entities;

namespace PoliceAbsenceService.Domain.Repositories;

public interface IPatrolRepository
{
    Task AddAsync(PatrolSchedule patrol, CancellationToken cancellationToken = default);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
