namespace DataPatrolTask.Models
{
    public class PolicyAssignment
    {
        public string PolicyId { get; set; }
        public PolicyTable Policy { get; set; }

        public string GroupId { get; set; }
        public UserGroup Group { get; set; }
    }
}
