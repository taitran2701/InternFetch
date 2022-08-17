using InternBA.Models;

namespace InternBA.Interfaces
{
    public interface IUserServiceRepository
    {
        Task<bool> IsValidUserAsync(User user);
        UserRefreshTokens AddUserRefreshTokens(UserRefreshTokens user);
        UserRefreshTokens GetSavedRefreshTokens(string username, string refreshToken);
        void DeleteUserRefreshTokens(string username, string refreshToken);
        int SaveCommit();
    }
}
