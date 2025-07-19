using PoliceAbsenceService.Application.DTOs;
using PoliceAbsenceService.Domain.Entities;
using PoliceAbsenceService.Domain.Enums;
using PoliceAbsenceService.Domain.Repositories;

namespace PoliceAbsenceService.Application.Services;

public class PatrolSchedulingService : IPatrolSchedulingService
{
    private readonly IAbsenceDeclarationRepository _declarationRepository;
    private readonly IPatrolRepository _patrolRepository;

    public PatrolSchedulingService(IAbsenceDeclarationRepository declarationRepository, IPatrolRepository patrolRepository)
    {
        _declarationRepository = declarationRepository;
        _patrolRepository = patrolRepository;
    }

    public async Task<Result> GeneratePatrolScheduleAsync(
        Guid declarationId,
        CancellationToken cancellationToken = default)
    {
        var declaration = await _declarationRepository.GetByIdAsync(declarationId);
        if (declaration == null)
            return Result.Failure("Déclaration introuvable");

        var patrolDates = GeneratePatrolDates(declaration.StartDate, declaration.EndDate);

        foreach (var date in patrolDates)
        {
            var patrol = new PatrolSchedule
            {
                AbsenceDeclarationId = declarationId,
                AbsenceDeclaration = declaration,
                ScheduledDate = date.Date,
                ScheduledTime = GenerateRandomPatrolTime(),
                Status = PatrolStatus.Scheduled,
                AssignedOfficer = await AssignOfficerForDate(date)
            };

            await _patrolRepository.AddAsync(patrol);
        }

        await _patrolRepository.SaveChangesAsync();
        return Result.Success();
    }

    private TimeSpan GenerateRandomPatrolTime()
    {
        return new TimeSpan(
            Random.Shared.Next(0, 24), // Heure aléatoire
            Random.Shared.Next(0, 60), // Minute aléatoire
            0); // Seconde fixe à 0
    }

    private async Task<string> AssignOfficerForDate(DateTime date)
    {
        return "Officer_" + date.DayOfWeek; // Simplicité, assignation basée sur le jour de la semaine
    }

    private List<DateTime> GeneratePatrolDates(DateTime start, DateTime end)
    {
        var dates = new List<DateTime>();
        var current = start;

        while (current <= end)
        {
            // Patrouilles tous les 2-3 jours de manière aléatoire
            if (Random.Shared.NextDouble() > 0.4) // 60% de chance
                dates.Add(current);

            current = current.AddDays(Random.Shared.Next(1, 4));
        }

        return dates;
    }
}
