using PoliceAbsenceService.Domain.Enums;

namespace PoliceAbsenceService.Application.DTOs;

public class CreateAbsenceDeclarationRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public string Address { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public decimal? Latitude { get; set; }
    public decimal? Longitude { get; set; }

    public DateTime StartDate { get; set; }
    public TimeSpan? StartTime { get; set; }
    public DateTime EndDate { get; set; }
    public TimeSpan? EndTime { get; set; }

    public AbsenceReason? Reason { get; set; }
    public string Comments { get; set; }
    public string EmergencyContact { get; set; }
}
