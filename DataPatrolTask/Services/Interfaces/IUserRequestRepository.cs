using DataPatrolTask.Models;

namespace DataPatrolTask.Services.Interfaces
{
    public interface IUserRequestRepository
    {
        Task<IEnumerable<UserRequest>> GetAllAsync();
        Task<UserRequest?> GetByIdAsync(long requestId);
        Task<UserRequest> CreateAsync(UserRequest request);
        Task<UserRequest?> UpdateAsync(long requestId, UserRequest request);
        Task<UserRequest?> DeleteAsync(long requestId);

        Task<IEnumerable<UserRequest>> GetRequestsByUserIdAsync(string userId);
    }
}
