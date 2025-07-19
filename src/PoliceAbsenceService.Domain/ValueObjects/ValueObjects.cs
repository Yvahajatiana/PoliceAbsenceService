namespace PoliceAbsenceService.Domain.ValueObjects;

public record Address(
    string Street,
    string City,
    string PostalCode,
    decimal? Latitude = null,
    decimal? Longitude = null
);

public record ContactInfo(
    string Email,
    string Phone,
    string? EmergencyContact = null
);
