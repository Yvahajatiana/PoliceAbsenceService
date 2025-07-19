using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PoliceAbsenceService.Domain.Entities;

namespace PoliceAbsenceService.Infrastructure.Data.Configurations;

public class AbsenceDeclarationConfiguration : IEntityTypeConfiguration<AbsenceDeclaration>
{
    public void Configure(EntityTypeBuilder<AbsenceDeclaration> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(x => x.Address)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(x => x.Latitude)
            .HasPrecision(10, 7);

        builder.Property(x => x.Longitude)
            .HasPrecision(10, 7);

        builder.HasMany(x => x.PatrolSchedules)
            .WithOne(x => x.AbsenceDeclaration)
            .HasForeignKey(x => x.AbsenceDeclarationId);

        builder.HasIndex(x => new { x.Address, x.StartDate, x.EndDate });
        builder.HasIndex(x => x.Status);
        builder.HasIndex(x => x.CreatedAt);
    }
}
