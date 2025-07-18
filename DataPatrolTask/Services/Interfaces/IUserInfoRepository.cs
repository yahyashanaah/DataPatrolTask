using DataPatrolTask.Models;

namespace DataPatrolTask.Services.Interfaces
{
    public interface IUserInfoRepository
    {
        Task<IEnumerable<UserInfo>> GetAllAsync();
        Task<UserInfo?> GetByIdAsync(string userId);
        Task<UserInfo> CreateAsync(UserInfo userInfo);
        Task<UserInfo?> UpdateAsync(string userId, UserInfo userInfo);
        Task<UserInfo?> DeleteAsync(string userId);
        Task<bool> DisableUserAsync(string userId);
        Task<IEnumerable<UserGroup>> GetUserGroupsAsync(string userId);
        Task<bool> AssignUserGroupsAsync(string userId, List<string> groupIds);
        // For API Core Project
        Task<bool> ExistsByUserIdAsync(string userId);

    }
}
