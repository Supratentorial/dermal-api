using dermal.api.Data;
using dermal.api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Threading.Tasks;

namespace dermal.api.Services
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly DermalDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public DatabaseInitializer(DermalDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task Seed()
        {
            await context.Database.EnsureCreatedAsync();

            const string email = "blake.mumford@indoctrinate.com.au";
            ApplicationUser user;

            if (await userManager.FindByEmailAsync(email) == null)
            {
                user = new ApplicationUser
                {
                    UserName = "root",
                    Email = email,
                    EmailConfirmed = true,
                    GivenName = "Blake",
                    FamilyName = "Mumford"
                };
                await userManager.CreateAsync(user, "P4ssw0rd!");
            }
        }
    }

    public interface IDatabaseInitializer
    {
        Task Seed();
    }
}
