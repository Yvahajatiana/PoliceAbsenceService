using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PoliceAbsenceService.Domain.Entities;
using PoliceAbsenceService.Domain.Enums;

namespace PoliceAbsenceService.Infrastructure.Data.Configurations;

public class PatrolScheduleConfiguration : IEntityTypeConfiguration<PatrolSchedule>
{
    public void Configure(EntityTypeBuilder<PatrolSchedule> builder)
    {
        // Clé primaire
        builder.HasKey(x => x.Id);

        // Propriétés requises
        builder.Property(x => x.AbsenceDeclarationId)
            .IsRequired();

        builder.Property(x => x.ScheduledDate)
            .IsRequired();

        builder.Property(x => x.ScheduledTime)
            .IsRequired();

        builder.Property(x => x.Status)
            .IsRequired()
            .HasConversion<int>()
            .HasDefaultValue(PatrolStatus.Scheduled);

        // Propriétés optionnelles
        builder.Property(x => x.AssignedOfficer)
            .HasMaxLength(200);

        builder.Property(x => x.CompletedAt);

        builder.Property(x => x.Notes)
            .HasMaxLength(1000);

        // Relations
        builder.HasOne(x => x.AbsenceDeclaration)
            .WithMany(x => x.PatrolSchedules)
            .HasForeignKey(x => x.AbsenceDeclarationId)
            .OnDelete(DeleteBehavior.NoAction);

        // Index pour les performances
        builder.HasIndex(x => x.AbsenceDeclarationId);
        builder.HasIndex(x => new { x.ScheduledDate, x.Status });
        builder.HasIndex(x => x.AssignedOfficer);
        builder.HasIndex(x => x.Status);
    }
}
