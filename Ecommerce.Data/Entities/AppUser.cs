using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Data.Entities
{
    public class AppUser : IdentityUser
    {
        public required string Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; } = string.Empty;
        public string? Picture { get; set; } = string.Empty;
        public DateTime DateCreate { get; set; } = DateTime.UtcNow;
    }
}