using DataPatrolTask.DataMigration;
using DataPatrolTask.Models;
using DataPatrolTask.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace DataPatrolTask.Services.Repositories
{
    public class PolicyTableRepository : IPolicyTableRepository
    {
        private readonly AppDbContext context;
        public PolicyTableRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<PolicyTable>> GetAllAsync()
        {
            try
            {
                return await context.PolicyTables.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return await context.PolicyTables.ToListAsync();
        }
        // Create New Policy
        public async Task<PolicyTable> CreateAsync(PolicyTable policy)
        {
            context.PolicyTables.Add(policy);
            await context.SaveChangesAsync();
            return policy;
        }
        
        // get Policy By Id 
        public async Task<PolicyTable?> GetByIdAsync(string policyId)
        {
            return await context.PolicyTables.FirstOrDefaultAsync( x => x.PolicyId == policyId);
        }

        public async Task<PolicyTable?> UpdateAsync(string policyId, PolicyTable policy)
        {
            var result = await context.PolicyTables.FindAsync(policyId);

            if (result == null)
            {
                return null;
            }

            result.PolicyName = policy.PolicyName;
            result.PolicyType = policy.PolicyType;
            result.IsDefault = policy.IsDefault;
            result.IsEnabled = policy.IsEnabled;

            await context.SaveChangesAsync();
            return result;
        }
        // Delete Policy By Id
        public async Task<PolicyTable?> DeleteAsync(string policyId)
        {
            var result = await context.PolicyTables.FindAsync(policyId);
            if (result == null)
            {
                return null;
            }

            context.PolicyTables.Remove(result);
            await context.SaveChangesAsync();
            return result;
        }

        public async Task<List<string>> GetPolicyIdsByGroupIdAsync(string groupId)
        {
            return await context.PolicyAssignments
                .Where(x => x.GroupId == groupId)
                .Select(x => x.PolicyId)
                .ToListAsync();
        }

        // Assign Policies To User Group
        public async Task AssignPoliciesToGroupAsync(string groupId, List<string> policyIds)
        {
            
            var existing = context.PolicyAssignments.Where(x => x.GroupId == groupId);
            context.PolicyAssignments.RemoveRange(existing);

            
            var newAssignments = policyIds.Select(policyId => new PolicyAssignment
            {
                GroupId = groupId,
                PolicyId = policyId
            });

            context.PolicyAssignments.AddRange(newAssignments);

            
            await context.SaveChangesAsync();
        }

        public async Task<List<string>> GetGroupIdsByPolicyIdAsync(string policyId)
        {
            
            return await context.PolicyAssignments
                .Where(x => x.PolicyId == policyId)
                .Select(x => x.GroupId)
                .ToListAsync();
        }

        public async Task AssignGroupsToPolicyAsync(string policyId, List<string> groupIds)
        {
            

            var existing = context.PolicyAssignments.Where(x => x.PolicyId == policyId);
            context.PolicyAssignments.RemoveRange(existing);

            var newAssignments = groupIds.Select(groupId => new PolicyAssignment
            {
                PolicyId = policyId,
                GroupId = groupId
            });

            context.PolicyAssignments.AddRange(newAssignments);
            await context.SaveChangesAsync();
        }



    }
}
