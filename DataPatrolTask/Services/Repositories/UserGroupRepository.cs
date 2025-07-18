using DataPatrolTask.DataMigration;
using DataPatrolTask.Models;
using DataPatrolTask.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataPatrolTask.Services.Repositories
{
    public class UserGroupRepository : IUserGroupRepository
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public UserGroupRepository(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<string>> GetGroupIdsForUserAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return new List<string>();

            await using var context = _contextFactory.CreateDbContext();

            var groupIds = await context.UserGroupsMembership
                .Where(x => x.UserId == userId)
                .Select(x => x.GroupId)
                .ToListAsync();

            return groupIds;
        }

        public async Task<IEnumerable<UserGroup>> GetAllAsync()
        {
            await using var context = _contextFactory.CreateDbContext();

            var groups = await context.UserGroups
                .AsNoTracking()
                .ToListAsync();

            Console.WriteLine($"[UserGroupRepository] Loaded {groups.Count} total groups");

            return groups;
        }

        public async Task<UserGroup> CreateAsync(UserGroup group)
        {
            await using var context = _contextFactory.CreateDbContext();
            context.UserGroups.Add(group);
            await context.SaveChangesAsync();
            return group;
        }

        public async Task<UserGroup?> GetByIdAsync(string groupId)
        {
            await using var context = _contextFactory.CreateDbContext();
            return await context.UserGroups.FirstOrDefaultAsync(x => x.GroupId == groupId);
        }

        public async Task<UserGroup?> UpdateAsync(string groupId, UserGroup group)
        {
            await using var context = _contextFactory.CreateDbContext();
            var result = await context.UserGroups.FindAsync(groupId);
            if (result == null) return null;

            result.Description = group.Description;
            await context.SaveChangesAsync();
            return result;
        }

        public async Task<UserGroup?> DeleteAsync(string groupId)
        {
            await using var context = _contextFactory.CreateDbContext();
            var result = await context.UserGroups.FindAsync(groupId);
            if (result == null) return null;

            context.UserGroups.Remove(result);
            await context.SaveChangesAsync();
            return result;
        }

        public async Task AssignPoliciesAsync(string groupId, List<string> policyIds)
        {
            await using var context = _contextFactory.CreateDbContext();
            var policies = context.PolicyAssignments.Where(x => x.GroupId == groupId);
            context.PolicyAssignments.RemoveRange(policies);

            foreach (var policyId in policyIds)
            {
                context.PolicyAssignments.Add(new PolicyAssignment
                {
                    GroupId = groupId,
                    PolicyId = policyId
                });
            }

            await context.SaveChangesAsync();
        }

        public async Task<List<string>> GetUserIdsByGroupAsync(string groupId)
        {
            await using var context = _contextFactory.CreateDbContext();
            return await context.UserGroupsMembership
                .Where(x => x.GroupId == groupId)
                .Select(x => x.UserId)
                .ToListAsync();
        }

        public async Task AssignUserGroupsAsync(string groupId, List<string> userIds)
        {
            await using var context = _contextFactory.CreateDbContext();
            var existing = context.UserGroupsMembership.Where(x => x.GroupId == groupId);
            context.UserGroupsMembership.RemoveRange(existing);

            foreach (var userId in userIds)
            {
                context.UserGroupsMembership.Add(new UserGroupMembership
                {
                    GroupId = groupId,
                    UserId = userId
                });
            }

            await context.SaveChangesAsync();
        }

        public async Task<List<string>> GetGroupIdsByUserIdAsync(string userId)
        {
            await using var context = _contextFactory.CreateDbContext();
            return await context.UserGroupsMembership
                .Where(x => x.UserId == userId)
                .Select(x => x.GroupId)
                .ToListAsync();
        }

        public async Task<List<string>> GetUserIdsByGroupId(string groupId)
        {
            await using var context = _contextFactory.CreateDbContext();
            return await context.UserGroupsMembership
                .Where(x => x.GroupId == groupId)
                .Select(x => x.UserId)
                .ToListAsync();
        }
        public async Task<List<string>> GetpolIdsByGroupId(string groupId)
        {
            await using var context = _contextFactory.CreateDbContext();
            return await context.PolicyAssignments
                .Where(x => x.GroupId == groupId)
                .Select(x => x.PolicyId)
                .ToListAsync();
        }

        //public async Task<List<string>> GetGroupIdsForUserAsync(string userId)
        //{
        //    await using var context = _contextFactory.CreateDbContext();
        //    return await context.UserGroupsMembership
        //        .Where(x => x.UserId == userId)
        //        .Select(x => x.GroupId)
        //        .ToListAsync();
        //}



        public async Task AssignGroupsToUserAsync(string userId, List<string> groupIds)
        {
            await using var context = _contextFactory.CreateDbContext();
            var existing = context.UserGroupsMembership.Where(x => x.UserId == userId);
            context.UserGroupsMembership.RemoveRange(existing);

            var newMemberships = groupIds.Select(groupId => new UserGroupMembership
            {
                UserId = userId,
                GroupId = groupId
            });

            context.UserGroupsMembership.AddRange(newMemberships);
            await context.SaveChangesAsync();
        }

        // Assign Users To Group
        public async Task AssignUsersToGroup(string groupId, List<string> userIds)
        {
            await using var context = _contextFactory.CreateDbContext();
            var existing = context.UserGroupsMembership.Where(x => x.GroupId == groupId);
            context.UserGroupsMembership.RemoveRange(existing);

            var newMemberships = userIds.Select(userId => new UserGroupMembership
            {
                UserId = userId,
                GroupId = groupId
            });

            context.UserGroupsMembership.AddRange(newMemberships);
            await context.SaveChangesAsync();
        } 
        
        // Assign Policies To Group
        public async Task AssignPolToGroup(string groupId, List<string> polIds)
        {
            await using var context = _contextFactory.CreateDbContext();
            var existing = context.PolicyAssignments.Where(x => x.GroupId == groupId);
            context.PolicyAssignments.RemoveRange(existing);

            var newMemberships = polIds.Select(polId => new PolicyAssignment
            {
               PolicyId = polId,
                GroupId = groupId
            });

            context.PolicyAssignments.AddRange(newMemberships);
            await context.SaveChangesAsync();
        }
    }
}