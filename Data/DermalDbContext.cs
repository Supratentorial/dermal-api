using Microsoft.EntityFrameworkCore;

public class DermalDbContext : DbContext
{
    public DermalDbContext(DbContextOptions<DermalDbContext> options) : base(options)
    {
        
    }

    public DbSet<ReferralRequest> ReferralRequests { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Practitioner> Practitioners { get; set; }
}