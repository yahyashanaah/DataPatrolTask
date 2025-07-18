using System.ComponentModel.DataAnnotations;

namespace DataPatrolTask.Models
{
    public class UserInfo
    {
        [Key]
        public string UserId { get; set; } 
        public string Username { get; set; }
        public bool IsEnabled { get; set; } = true;
        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
        public string TenantId { get; set; }

        public ICollection<UserGroupMembership> UserGroupMemberships { get; set; }
        public ICollection<UserRequest> UserRequests { get; set; }
    }
}
