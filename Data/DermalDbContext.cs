using dermal.api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace dermal.api.Data
{
    public class DermalDbContext : IdentityDbContext<ApplicationUser>
    {
        public DermalDbContext(DbContextOptions<DermalDbContext> options) : base(options)
        {
            
        }

        public DbSet<ReferralRequest> ReferralRequests { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Practitioner> Practitioners { get; set; }
    }
}