using BlazorApp2.Models;

namespace BlazorApp2.Services
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
        Task<User> GetUser(int id);
        Task AddUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(int id);
    }
}
