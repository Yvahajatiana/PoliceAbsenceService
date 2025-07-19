using PoliceAbsenceService.Domain.Enums;

namespace PoliceAbsenceService.Application.DTOs;

public class AbsenceDeclarationResponse
{
    public Guid Id { get; set; }
    // public string DeclarationNumber { get; set; }
    public required string FullName { get; set; }
    public required string Address { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DeclarationStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    // public List<PatrolScheduleDto> ScheduledPatrols { get; set; }
}
