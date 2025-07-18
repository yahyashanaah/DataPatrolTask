using System.ComponentModel.DataAnnotations;

namespace DataPatrolTask.Models
{
    public class UserGroup
    {
        [Key]
        public string GroupId { get; set; } = Guid.NewGuid().ToString();
        public string Description { get; set; }

        public ICollection<UserGroupMembership> UserGroupMemberships { get; set; }
        public ICollection<PolicyAssignment> PolicyAssignments { get; set; }
    }
}
