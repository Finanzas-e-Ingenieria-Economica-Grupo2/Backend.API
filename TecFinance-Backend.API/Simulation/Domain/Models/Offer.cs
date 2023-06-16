namespace TecFinance_Backend.API.Simulation.Domain.Models;

public class Offer
{
    public Offer()
    {
    }
    
    public Offer(List<Payment> payments)
    {
        Payments = payments;
    }
    
    public int Id { get; set; }
    
    
    // Relationships
    public List<Payment> Payments { get; set; }
}