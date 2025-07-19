using PoliceAbsenceService.Domain.Entities;

namespace PoliceAbsenceService.Domain.Repositories;

public interface IAbsenceDeclarationRepository
{
    Task<AbsenceDeclaration?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<AbsenceDeclaration?> GetActiveDeclarationByAddressAsync(string address, DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
    
    Task AddAsync(AbsenceDeclaration declaration, CancellationToken cancellationToken = default);
    
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
