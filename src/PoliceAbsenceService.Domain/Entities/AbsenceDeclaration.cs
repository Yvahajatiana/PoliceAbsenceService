using PoliceAbsenceService.Domain.Enums;

namespace PoliceAbsenceService.Domain.Entities;

public class AbsenceDeclaration : BaseEntity
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? Email { get; set; }
    public required string Phone { get; set; }

    // Adresse
    public required string Address { get; set; }
    public required string City { get; set; }
    public required string PostalCode { get; set; }
    public decimal? Latitude { get; set; }
    public decimal? Longitude { get; set; }

    // Période d'absence
    public DateTime StartDate { get; set; }
    public TimeSpan? StartTime { get; set; }
    public DateTime EndDate { get; set; }
    public TimeSpan? EndTime { get; set; }

    // Informations complémentaires
    public AbsenceReason? Reason { get; set; }
    public string? Comments { get; set; }
    public required string EmergencyContact { get; set; }

    // Status et métadonnées
    public DeclarationStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ValidatedAt { get; set; }
    public required string ValidatedBy { get; set; }

    // Relations
    public List<PatrolSchedule> PatrolSchedules { get; set; } = [];
    public List<IncidentReport> IncidentReports { get; set; } = [];
}
