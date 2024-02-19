using Core;
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

        public async Task SeedRolesAsync(string cargo)
        {
            if (!await _roleManager.RoleExistsAsync(cargo.ToUpper()))
            {
                await _roleManager.CreateAsync(new IdentityRole("professor".ToUpper()));
            }
        }


        public async Task SeedUsersAsync(Pessoa pessoa, string cargo)
        {
            await SeedRolesAsync(cargo);


            var user = await _userManager.FindByNameAsync(pessoa.Email);

            if (user == null)
            {
                UsuarioIdentity newUser = new UsuarioIdentity
                {
                    Email = pessoa.Email,
                    UserName = pessoa.Email,
                    NormalizedEmail = pessoa.Email.ToUpper(),
                    NormalizedUserName = pessoa.Email.ToUpper(),
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                IdentityResult result = await _userManager.CreateAsync(newUser, "Matheus12");

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newUser, cargo.ToUpper());
                }
            }
            else
            {
                await _userManager.AddToRoleAsync(user, cargo.ToUpper());
            }


        }

    }
}
