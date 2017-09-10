using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using dermal.api.Data;
using dermal.api.Models;
using Microsoft.AspNetCore.Identity;
using AspNet.Security.OpenIdConnect.Primitives;
using dermal.api.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace dermal.api
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddCors();

            services.AddDbContext<DermalDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DermalDb"));
                options.UseOpenIddict();
            });

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<DermalDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.ClaimsIdentity.UserNameClaimType = OpenIdConnectConstants.Claims.Name;
                options.ClaimsIdentity.UserIdClaimType = OpenIdConnectConstants.Claims.Subject;
                options.ClaimsIdentity.RoleClaimType = OpenIdConnectConstants.Claims.Role;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Events = new CookieAuthenticationEvents
                {
                    OnRedirectToLogin = context => {
                        if (context.Request.Path.StartsWithSegments("/api"))
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        }
                        else {
                            context.Response.Redirect(context.RedirectUri);
                        }
                        return Task.FromResult(0);
                    }
                };
            });

            services.AddOpenIddict(options =>
            {
                options.AddEntityFrameworkCoreStores<DermalDbContext>();
                options.AddMvcBinders();
                options.EnableTokenEndpoint("/connect/token");
                options.AllowPasswordFlow();
                options.AllowRefreshTokenFlow();
                //During development disable the HTTPS requirement
                options.DisableHttpsRequirement();
            });

            services.AddAuthentication()
                .AddOAuthValidation();

            //seed the database
            services.AddTransient<IDatabaseInitializer, DatabaseInitializer>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IDatabaseInitializer databaseInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseAuthentication();

            databaseInitializer.Seed().GetAwaiter().GetResult();

            app.UseDefaultFiles();
            app.UseStaticFiles();
           
            app.UseMvc();
        }
    }
}
