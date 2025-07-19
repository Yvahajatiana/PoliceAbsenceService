using AutoMapper;
using Microsoft.Extensions.Logging;
using PoliceAbsenceService.Application.DTOs;
using PoliceAbsenceService.Domain.Entities;
using PoliceAbsenceService.Domain.Enums;
using PoliceAbsenceService.Domain.Repositories;

namespace PoliceAbsenceService.Application.Services;

public class AbsenceDeclarationService : IAbsenceDeclarationService
{
    private readonly IAbsenceDeclarationRepository _repository;
    //private readonly INotificationService _notificationService;
    private readonly IMapper _mapper;
    private readonly ILogger<AbsenceDeclarationService> _logger;

    public AbsenceDeclarationService(
        IAbsenceDeclarationRepository repository,
        //INotificationService notificationService,
        IMapper mapper,
        ILogger<AbsenceDeclarationService> logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        //_notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<Result<AbsenceDeclarationResponse>> CreateDeclarationAsync(CreateAbsenceDeclarationRequest request, CancellationToken cancellationToken = default)
    {
        try
        {
            // Validation métier
            var validationResult = await ValidateDeclarationRequest(request);
            if (!validationResult.IsSuccess)
                return Result<AbsenceDeclarationResponse>.Failure(validationResult.Error ?? "");

            // Création de l'entité
            var declaration = _mapper.Map<AbsenceDeclaration>(request);
            declaration.Status = DeclarationStatus.Submitted;
            declaration.CreatedAt = DateTime.UtcNow;

            // Sauvegarde
            await _repository.AddAsync(declaration, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            // Notification par email
            //await _notificationService.SendDeclarationConfirmationAsync(declaration);

            var response = _mapper.Map<AbsenceDeclarationResponse>(declaration);
            return Result<AbsenceDeclarationResponse>.Success(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erreur lors de la création de la déclaration");
            return Result<AbsenceDeclarationResponse>.Failure("Erreur technique");
        }
    }

    private async Task<Result> ValidateDeclarationRequest(CreateAbsenceDeclarationRequest request)
    {
        // Validation des dates
        if (request.StartDate <= DateTime.Today)
            return Result.Failure("La date de début doit être dans le futur");

        if (request.EndDate <= request.StartDate)
            return Result.Failure("La date de fin doit être après la date de début");

        // Validation de la durée (min 24h, max 30 jours)
        var duration = request.EndDate - request.StartDate;
        if (duration.TotalHours < 24)
            return Result.Failure("La durée minimale d'absence est de 24 heures");

        if (duration.TotalDays > 30)
            return Result.Failure("La durée maximale d'absence est de 30 jours");

        // Vérification de doublons
        var existingDeclaration = await _repository.GetActiveDeclarationByAddressAsync(
            request.Address, request.StartDate, request.EndDate);

        if (existingDeclaration != null)
            return Result.Failure("Une déclaration existe déjà pour cette adresse sur cette période");

        return Result.Success();
    }
}
