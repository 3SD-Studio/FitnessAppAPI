using FitnessAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitnessAPI.Data {
    public class FitnessAppDbContext : IdentityDbContext<FitnesAppUser, IdentityRole, string> {
        public FitnessAppDbContext(DbContextOptions<FitnessAppDbContext> options) : base(options) { 
        
        }
    }
}
