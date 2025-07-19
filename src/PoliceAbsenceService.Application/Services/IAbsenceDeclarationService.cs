using PoliceAbsenceService.Application.DTOs;

namespace PoliceAbsenceService.Application.Services;

public interface IAbsenceDeclarationService
{
    Task<Result<AbsenceDeclarationResponse>> CreateDeclarationAsync(CreateAbsenceDeclarationRequest request, CancellationToken cancellationToken = default);

    /**
     * Future methods can be uncommented and implemented as needed
    Task<Result<AbsenceDeclarationResponse>> GetDeclarationAsync(Guid id, CancellationToken cancellationToken = default);

    Task<Result<List<AbsenceDeclarationResponse>>> GetDeclarationsByStatusAsync(DeclarationStatus status, CancellationToken cancellationToken = default);

    Task<Result> ApproveDeclarationAsync(Guid id, string approvedBy, CancellationToken cancellationToken = default);

    Task<Result> RejectDeclarationAsync(Guid id, string rejectedBy, string reason, CancellationToken cancellationToken = default);
    **/
}
