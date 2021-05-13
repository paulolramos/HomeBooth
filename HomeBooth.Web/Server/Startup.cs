using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HomeBooth.Data;
using HomeBooth.Data.Models;
using HomeBooth.Web.Server.Areas.Identity.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using Npgsql;
using System;
using Microsoft.AspNetCore.Identity;
using HomeBooth.Web.Shared;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace HomeBooth.Web.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionBuilder = new NpgsqlConnectionStringBuilder(Configuration.GetConnectionString("homebooth"))
            {
                Password = Configuration["DbPassword"]
            };

            var dbConnection = connectionBuilder.ConnectionString;

            services.AddDbContext<HomeBoothDbContext>(options =>
            {
                options.EnableDetailedErrors();
                options.UseNpgsql(dbConnection);
            });

            services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
            }).AddRoles<IdentityRole>().AddEntityFrameworkStores<HomeBoothDbContext>();

            services.AddIdentityServer().AddApiAuthorization<ApplicationUser, HomeBoothDbContext>(options =>
            {
                options.IdentityResources["openid"].UserClaims.Add("name");
                options.ApiResources.Single().UserClaims.Add("name");
                options.IdentityResources["openid"].UserClaims.Add("role");
                options.ApiResources.Single().UserClaims.Add("role");
            });
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("role");

            services.Configure<IdentityOptions>(options =>
                options.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier);

            services.AddAuthentication().AddIdentityServerJwt();

            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<EmailSenderOptions>(Configuration.GetSection(EmailSenderOptions.EmailSender));

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });

            CreateRoles(serviceProvider);
        }

        private static void CreateRoles(IServiceProvider serviceProvider)
        {
            var roles = new string[] { AccountType.Client, AccountType.Host };
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            foreach (var role in roles)
            {
                var hasRole = roleManager.RoleExistsAsync(role);
                hasRole.Wait();

                if (!hasRole.Result)
                {
                    roleManager.CreateAsync(new IdentityRole(role)).Wait();
                }
            }

        }
    }
}
