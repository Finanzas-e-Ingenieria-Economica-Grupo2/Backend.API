namespace TecFinance_Backend.API.Simulation.Domain.Models;

public class Schedule
{
    public Schedule()
    {
    }
    
    public Schedule(List<Payment> payments)
    {
        Payments = payments;
    }
    
    public int Id { get; set; }
    
    
    // Relationships
    public List<Payment> Payments { get; set; }
}