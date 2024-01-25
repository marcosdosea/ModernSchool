using Microsoft.AspNetCore.Identity;
using ModernSchoolWEB.Areas.Identity.Data;

namespace ModernSchoolWEB.Service
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<UsuarioIdentity> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedUserRoleInitial(UserManager<UsuarioIdentity> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedRolesAsync()
        {
            if (!await _roleManager.RoleExistsAsync("Professor"))
            {
                await _roleManager.CreateAsync(new IdentityRole("professor".ToUpper()));
            }
        }

        public async Task SeedUsersAsync()
        {
            if (await _userManager.FindByEmailAsync("matheusmt@abc.com") == null)
            {
                var user = CreateUser();

                user.Email = "matheusmt@abc.com";

                await _userManager.CreateAsync(user, "Matheus123");
            }
        }


        private UsuarioIdentity CreateUser()
        {
            try
            {
                return Activator.CreateInstance<UsuarioIdentity>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(UsuarioIdentity)}'. " +
                    $"Ensure that '{nameof(UsuarioIdentity)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }
    }
}
