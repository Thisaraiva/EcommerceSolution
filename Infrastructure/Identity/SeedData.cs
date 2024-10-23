using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

public class SeedData
{
    public static async Task Initialize(IServiceProvider serviceProvider, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        var logger = serviceProvider.GetRequiredService<ILogger<SeedData>>();

        string[] roles = { "Admin", "Employee", "Customer" };

        // Seed roles
        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
                logger.LogInformation($"Role '{role}' criada com sucesso.");
            }
            else
            {
                logger.LogInformation($"Role '{role}' já existe.");
            }
        }

        // Seed Admin user
        var adminEmail = "admin@admin.com"; // Defina um email para o admin
        var adminPassword = "Admin@123"; // Defina uma senha para o admin

        var adminUser = await userManager.FindByEmailAsync(adminEmail);
        if (adminUser == null)
        {
            adminUser = new ApplicationUser {
                UserName = adminEmail,
                Email = adminEmail,
                FirstName = "Admin",    // Definindo o FirstName obrigatório
                LastName = "User",      // Definindo o LastName obrigatório
                BirthDate = new DateTime(1990, 1, 1) // Defina a data de nascimento
            };
            var result = await userManager.CreateAsync(adminUser, adminPassword);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
                logger.LogInformation($"Usuário Admin '{adminEmail}' criado com sucesso e atribuído à role 'Admin'.");
            }
            else
            {
                logger.LogError("Erro ao criar o usuário Admin: " + string.Join(", ", result.Errors.Select(e => e.Description)));
            }
        }
        else
        {
            logger.LogInformation($"Usuário Admin '{adminEmail}' já existe.");
        }
    }
}
