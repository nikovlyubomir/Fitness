using Fitness.Web.Data;
using Fitness.Web.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Fitness.Web.Infrastructure
{
    public static class DatabaseMigrationExtensions
    {
        public static IApplicationBuilder MigrateDatabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<ApplicationDbContext>().Database.Migrate();

                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
                var userManager = serviceScope.ServiceProvider.GetService<UserManager<ApplicationUser>>();

                Task.Run(async () =>
                {
                    foreach (var role in GlobalConstants.Roles)
                    {
                        var roleExists = await roleManager.RoleExistsAsync(role);

                        if (!roleExists)
                        {
                            await roleManager.CreateAsync(new IdentityRole
                            {
                                Name = role
                            });
                        }
                    }

                    var adminEmail = "lyube@email.com";
                    var adminExists = await userManager.FindByEmailAsync(adminEmail);

                    if (adminExists == null)
                    {
                        var admin = new ApplicationUser
                        {
                            Email = adminEmail,
                            UserName = adminEmail
                        };

                        await userManager.CreateAsync(admin, "password");
                        await userManager.AddToRoleAsync(admin, GlobalConstants.AdministratorRole);
                    }

                }).Wait();
            }

            return app;
        }
    }
}