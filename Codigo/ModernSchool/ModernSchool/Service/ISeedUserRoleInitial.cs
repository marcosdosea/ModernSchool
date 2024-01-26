using Core;

namespace ModernSchoolWEB.Service
{
    public interface ISeedUserRoleInitial
    {
        Task SeedRolesAsync(string cargo);
        Task SeedUsersAsync(Pessoa pessoa, string cargo);

    }
}
