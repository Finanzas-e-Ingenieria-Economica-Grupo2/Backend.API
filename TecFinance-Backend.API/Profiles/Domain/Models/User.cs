namespace TecFinance_Backend.API.Profiles.Domain.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Mail { get; set; }
    public string Password { get; set; }
}