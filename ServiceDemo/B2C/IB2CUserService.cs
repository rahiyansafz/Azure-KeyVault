using Microsoft.Graph;

namespace B2C
{
    public interface IB2CUserService
    {
        Task<User> CreateAsync(User user);
        Task DeleteAsync(string objectId);
        Task<User> GetUserAsync(string objectId);
        Task<User> GetbyEmailAsync(string email);
        Task<bool> UserExistsByEmail(string email);

        Task<Invitation> InviteUser(Invitation invitation);
    }
}
