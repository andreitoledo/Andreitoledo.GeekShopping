using Andreitoledo.GeekShopping.IdentityServer.Configuration;
using Andreitoledo.GeekShopping.IdentityServer.Initializer;
using Andreitoledo.GeekShopping.IdentityServer.Model;
using Andreitoledo.GeekShopping.IdentityServer.Model.Context;
using Andreitoledo.GeekShopping.IdentityServer.Services;
using Duende.IdentityServer.AspNetIdentity;
using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Andreitoledo.GeekShopping.IdentityServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Conexão com o banco MySQL - andrei
            var connection = builder.Configuration["MySqlConnection:MySqlConnectionString"];
            builder.Services.AddDbContext<MySQLContext>(options => options.UseMySql(
                connection,
                new MySqlServerVersion(new Version(8, 0, 0))));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<MySQLContext>()
                .AddDefaultTokenProviders();

            var builderServices = builder.Services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
                options.EmitStaticAudienceClaim = true;
            })
                .AddInMemoryIdentityResources(IdentityConfiguration.IdentityResources)
                .AddInMemoryApiScopes(IdentityConfiguration.ApiScopes)
                .AddInMemoryClients(IdentityConfiguration.Clients)
                .AddAspNetIdentity<ApplicationUser>();

            builder.Services.AddScoped<IDbInitializer, DbInitializer>();
            builder.Services.AddScoped<IProfileService, ProfileService>();

            builderServices.AddDeveloperSigningCredential();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            var initializer = app.Services.CreateScope().ServiceProvider.GetService<IDbInitializer>();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseIdentityServer();
            app.UseAuthorization();

            initializer.Initialize();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}