using Microsoft.EntityFrameworkCore;
using PoliceAbsenceService.Domain.Entities;

namespace PoliceAbsenceService.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<AbsenceDeclaration> AbsenceDeclarations { get; set; }
    public DbSet<PatrolSchedule> PatrolSchedules { get; set; }
    public DbSet<IncidentReport> IncidentReports { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
