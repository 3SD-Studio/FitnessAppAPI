using Microsoft.AspNetCore.Identity;

namespace FitnessAPI.Models {
    public class FitnesAppUser : IdentityUser {
        public DateTime? DateOfBirth{ get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
    }
}
