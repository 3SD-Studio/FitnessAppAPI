using FitnessAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitnessAPI.Data {
    public class FitnessAppDBContext : IdentityDbContext<FitnesAppUser, IdentityRole, string> {
        public FitnessAppDBContext(DbContextOptions<FitnessAppDBContext> options) : base(options) { 
        
        }
    }
}
