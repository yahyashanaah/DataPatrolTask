using DataPatrolTask.Models;

namespace DataPatrolTask.Services.Interfaces
{
    public interface IUserGroupRepository
    {
        Task<IEnumerable<UserGroup>> GetAllAsync();
        Task<UserGroup?> GetByIdAsync(string groupId);
        Task<UserGroup> CreateAsync(UserGroup group);
        Task<UserGroup?> UpdateAsync(string groupId, UserGroup group);
        Task<UserGroup?> DeleteAsync(string groupId);

        Task AssignUserGroupsAsync(string groupId, List<string> userIds);
        Task<List<string>> GetUserIdsByGroupAsync(string groupId);
        Task AssignPoliciesAsync(string groupId, List<string> policyIds);
        Task<List<string>> GetGroupIdsForUserAsync(string userId);
        Task<List<string>> GetGroupIdsByUserIdAsync(string userId);
        Task<List<string>> GetUserIdsByGroupId(string groupId);
        Task<List<string>> GetpolIdsByGroupId(string groupId);


        Task AssignGroupsToUserAsync(string userId, List<string> groupIds);
        Task AssignUsersToGroup(string groupId, List<string> userIds); Task AssignPolToGroup(string groupId, List<string> userIds);


    }
}
