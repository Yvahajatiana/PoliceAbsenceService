using PoliceAbsenceService.Domain.Enums;

namespace PoliceAbsenceService.Domain.Entities;

public class IncidentReport : BaseEntity
{
    public Guid AbsenceDeclarationId { get; set; }
    public AbsenceDeclaration AbsenceDeclaration { get; set; }

    public DateTime IncidentDate { get; set; }
    public IncidentType Type { get; set; }
    public string Description { get; set; }
    public string ReportingOfficer { get; set; }

    public bool OwnerNotified { get; set; }
    public DateTime? NotificationSentAt { get; set; }
}
