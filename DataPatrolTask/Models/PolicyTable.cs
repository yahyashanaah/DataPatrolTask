using System.ComponentModel.DataAnnotations;

namespace DataPatrolTask.Models
{
    public class PolicyTable
    {
        [Key]
        public string PolicyId { get; set; } = Guid.NewGuid().ToString();
        public string PolicyName { get; set; }
        public bool IsDefault { get; set; }
        public int PolicyType { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;

        public ICollection<PolicyAssignment> PolicyAssignments { get; set; }
    }
}
