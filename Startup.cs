using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using dermal.api.Data;
using IdentityServer4.AccessTokenValidation;
using dermal.api.Interfaces;
using dermal.api.Services;
using Microsoft.Extensions.Logging;

namespace dermal.api
{
    public class Startup
    {

        private readonly IHostingEnvironment env;

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.AddMvc();

            services.AddDbContext<DermalDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DermalDb"));
            });

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = Configuration["IdentityServerHost"];
                    options.ApiName = "dermal-api";
                });

            services.AddAuthorization(options => { });

            services.AddTransient<IPatientMapper, PatientMapper>();
            services.AddTransient<IAgeUtilityMethods, AgeUtilityMethods>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");

            app.UseAuthentication();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
