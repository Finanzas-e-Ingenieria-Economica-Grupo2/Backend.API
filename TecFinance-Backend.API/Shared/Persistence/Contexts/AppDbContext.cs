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
    
    public DbSet<User> Users { get; set; }
    public DbSet<Bank> Banks { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Offer> Offers { get; set; }
    public DbSet<Configuration> Configurations { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // User Configuration
        
        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(b => b.Id);
        builder.Entity<User>().Property(b => b.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(c => c.Name).IsRequired().HasMaxLength(50);
        builder.Entity<User>().Property(c => c.Email).IsRequired().HasMaxLength(50);
        builder.Entity<User>().Property(c => c.Password).IsRequired().HasMaxLength(20);

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
        builder.Entity<Payment>().Property(p => p.CurrentPeriod).IsRequired();
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

        // Offer Configuration

        builder.Entity<Offer>().ToTable("Offers");
        builder.Entity<Offer>().HasKey(o => o.Id);
        builder.Entity<Offer>().Property(o => o.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Offer>().Property(o => o.HomeValue).IsRequired();
        builder.Entity<Offer>().Property(o => o.AmountToFinance).IsRequired();
        builder.Entity<Offer>().Property(o => o.IsHousingSupport).IsRequired();
        builder.Entity<Offer>().Property(o => o.IsHousingSustainable).IsRequired();
        builder.Entity<Offer>().Property(o => o.Tea).IsRequired();
        builder.Entity<Offer>().Property(o => o.Tna).IsRequired();
        builder.Entity<Offer>().Property(o => o.Capitalization).IsRequired();
        builder.Entity<Offer>().Property(o => o.TermInMonths).IsRequired();
        builder.Entity<Offer>().Property(o => o.Tcea).IsRequired();
        builder.Entity<Offer>().Property(o => o.Van).IsRequired();
        builder.Entity<Offer>().Property(o => o.Tir).IsRequired();

        // Configuration entity Configuration

        builder.Entity<Configuration>().ToTable("Configurations");
        builder.Entity<Configuration>().HasKey(c => c.Id);
        builder.Entity<Configuration>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Configuration>().Property(c => c.InterestRateType).IsRequired().HasMaxLength(10);
        builder.Entity<Configuration>().Property(c => c.Currency).IsRequired().HasMaxLength(10);
        builder.Entity<Configuration>().Property(c => c.AmountTotalGracePeriod).IsRequired();
        builder.Entity<Configuration>().Property(c => c.AmountPartialGracePeriod).IsRequired();

        // Relationships
        
        builder.Entity<Offer>()
            .HasMany(s => s.Payments)
            .WithOne(p => p.Offer)
            .HasForeignKey(p => p.OfferId);
        
        builder.Entity<Offer>()
            .HasOne(o => o.Configuration)
            .WithOne(c => c.Offer)
            .HasForeignKey<Configuration>(c => c.OfferId);

        // Apply Snake Case Naming Convention
        
        builder.UseSnakeCaseNamingConvention();
    }
}