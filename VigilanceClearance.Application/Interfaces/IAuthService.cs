using VigilanceClearance.Application.DTOs.Model;

namespace VigilanceClearance.Application.Interfaces
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(string email, string password, string role);
        Task<string> LoginAsync(string email, string password);
        Task<string> CreateRoleAsync(string roleName);
        Task<string> AssignRoleToUserAsync(string email, string roleName);


        Task<List<UserWithRolesDto>> GetAllUsers();
       
        Task<List<string>> GetRoleAsync();
        
    }
}
