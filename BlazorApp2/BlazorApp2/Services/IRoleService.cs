using BlazorApp2.Models;

namespace BlazorApp2.Services
{
    public interface IRoleService
    {
        Task<List<Role>> GetRoles();
    }
}
