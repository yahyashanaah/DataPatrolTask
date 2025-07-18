using DataPatrolTask.DataMigration;
using DataPatrolTask.Models;
using DataPatrolTask.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DataPatrolTask.Services.Repositories
{
    public class UserInfoRepository : IUserInfoRepository
    {
        private readonly AppDbContext context;
        public UserInfoRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<UserInfo>> GetAllAsync()
        {
            return await context.UserInfos.ToListAsync();
        }

        public async Task<UserInfo?> GetByIdAsync(string userId)
        {
            return await context.UserInfos.FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task<UserInfo> CreateAsync(UserInfo userInfo)
        {
            userInfo.IsEnabled = true;

            context.UserInfos.Add(userInfo);
            await context.SaveChangesAsync();
            return userInfo;
        }
       
        public async Task<UserInfo?> UpdateAsync(string userId, UserInfo userInfo)
        {
            var user = await context.UserInfos.FindAsync(userId);
            if (user == null)
            {
                return null;
            }

            user.Username = userInfo.Username;
            user.IsEnabled = userInfo.IsEnabled;

            await context.SaveChangesAsync();
            return user;
        }

        public async Task<UserInfo?> DeleteAsync(string userId)
        {
            try
            {
            var user = await context.UserInfos.FindAsync(userId);
            if (user == null)
            {
                return null;
            }

            context.UserInfos.Remove(user);
            await context.SaveChangesAsync();
            return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }

        // Disable User
        public async Task<bool> DisableUserAsync(string userId)
        {
            var user = await context.UserInfos.FindAsync(userId);
            if(user == null)
            {
                return false;
            }

            user.IsEnabled = false;
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<UserGroup>> GetUserGroupsAsync(string userId)
        {
            var result = await context.UserGroupsMembership.Where(x => x.UserId == userId)
                .Select(x => x.UserGroup).ToListAsync();
            return result;
        }

        // Assign User Groups
        public async Task<bool> AssignUserGroupsAsync(string userId, List<string> groupIds)
        {
            var result = context.UserGroupsMembership.Where(x => x.UserId == userId);
            context.UserGroupsMembership.RemoveRange(result);

            var addNewMember = groupIds.Select(groupId => new UserGroupMembership
            {
                UserId = userId,
                GroupId = groupId
            });

            context.UserGroupsMembership.AddRange(addNewMember);
            await context.SaveChangesAsync();
            return true;
        }

        // For Create new User Name
        public async Task<bool> ExistsByUserIdAsync(string userId)
        {
            return await context.UserInfos.AnyAsync(u => u.UserId == userId);
        }

    }
}
