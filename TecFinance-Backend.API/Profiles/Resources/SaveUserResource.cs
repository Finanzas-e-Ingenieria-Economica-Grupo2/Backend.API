using System.ComponentModel.DataAnnotations;

namespace TecFinance_Backend.API.Profiles.Resources;

public class SaveUserResource
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    [Required]
    [EmailAddress]
    [MaxLength(50)]
    public string Email { get; set; }
    
    [Required]
    [MaxLength(20)]
    public string Password { get; set; }
}