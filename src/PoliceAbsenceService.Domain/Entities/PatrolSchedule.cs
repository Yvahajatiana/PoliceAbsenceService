using PoliceAbsenceService.Domain.Enums;

namespace PoliceAbsenceService.Domain.Entities;

public class PatrolSchedule : BaseEntity
{
    public Guid AbsenceDeclarationId { get; set; }
    public required AbsenceDeclaration AbsenceDeclaration { get; set; }

    public DateTime ScheduledDate { get; set; }
    public TimeSpan ScheduledTime { get; set; }
    public required string AssignedOfficer { get; set; }
    public PatrolStatus Status { get; set; }

    public DateTime? CompletedAt { get; set; }
    public string? Notes { get; set; }
}
