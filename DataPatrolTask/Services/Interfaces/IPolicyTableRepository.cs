using DataPatrolTask.Models;

namespace DataPatrolTask.Services.Interfaces
{
    public interface IPolicyTableRepository
    {
        Task<IEnumerable<PolicyTable>> GetAllAsync();
        Task<PolicyTable?> GetByIdAsync(string policyId);
        Task<PolicyTable> CreateAsync(PolicyTable policy);
        Task<PolicyTable?> UpdateAsync(string policyId, PolicyTable policy);
        Task<PolicyTable?> DeleteAsync(string policyId);

        Task<List<string>> GetPolicyIdsByGroupIdAsync(string groupId);
        Task AssignPoliciesToGroupAsync(string groupId, List<string> policyIds);

        Task<List<string>> GetGroupIdsByPolicyIdAsync(string policyId);
        Task AssignGroupsToPolicyAsync(string policyId, List<string> groupIds);

    }
}
