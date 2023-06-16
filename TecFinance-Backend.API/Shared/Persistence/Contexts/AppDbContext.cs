using Microsoft.EntityFrameworkCore;
using TecFinance_Backend.API.Simulation.Domain.Models;
using TecFinance_Backend.API.Profiles.Domain.Models;
using TecFinance_Backend.API.Shared.Extensions;

namespace TecFinance_Backend.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Bank> Banks { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Schedule> Schedules { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Bank Configuration
        
        builder.Entity<Bank>().ToTable("Banks");
        builder.Entity<Bank>().HasKey(b => b.Id);
        builder.Entity<Bank>().Property(b => b.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Bank>().Property(c => c.Name).IsRequired().HasMaxLength(50);
        builder.Entity<Bank>().Property(c => c.LienInsurance).IsRequired();
        builder.Entity<Bank>().Property(c => c.PropertyInsurance).IsRequired();
        builder.Entity<Bank>().Property(c => c.ValuationExpenses).IsRequired();
        builder.Entity<Bank>().Property(c => c.TraditionalBbp).IsRequired();
        builder.Entity<Bank>().Property(c => c.SustainableBbp).IsRequired();
        builder.Entity<Bank>().Property(c => c.MinimumInitialFee).IsRequired();
        builder.Entity<Bank>().Property(c => c.MaximumPeriod).IsRequired();
        builder.Entity<Bank>().Property(c => c.MinimumPeriod).IsRequired();

        // Payment Configuration

        builder.Entity<Payment>().ToTable("Payments");
        builder.Entity<Payment>().HasKey(p => p.Id);
        builder.Entity<Payment>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Payment>().Property(p => p.Tep).IsRequired();
        builder.Entity<Payment>().Property(p => p.GracePeriod).IsRequired().HasMaxLength(10);
        builder.Entity<Payment>().Property(p => p.InitialBalance).IsRequired();
        builder.Entity<Payment>().Property(p => p.FinalBalance).IsRequired();
        builder.Entity<Payment>().Property(p => p.Interest).IsRequired();
        builder.Entity<Payment>().Property(p => p.Amortization).IsRequired();
        builder.Entity<Payment>().Property(p => p.Fee).IsRequired();
        builder.Entity<Payment>().Property(p => p.TotalFee).IsRequired();
        builder.Entity<Payment>().Property(p => p.LienInsurance).IsRequired();
        builder.Entity<Payment>().Property(p => p.PropertyInsurance).IsRequired();
        builder.Entity<Payment>().Property(p => p.ValuationExpenses).IsRequired();

        // Schedule Configuration

        builder.Entity<Schedule>().ToTable("Schedules");
        builder.Entity<Schedule>().HasKey(s => s.Id);
        builder.Entity<Schedule>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();

        // Relationships
        
        builder.Entity<Schedule>()
            .HasMany(s => s.Payments)
            .WithOne(p => p.Schedule)
            .HasForeignKey(p => p.ScheduleId);

        // Apply Snake Case Naming Convention
        
        builder.UseSnakeCaseNamingConvention();
    }
}