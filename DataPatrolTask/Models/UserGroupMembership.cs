namespace DataPatrolTask.Models
{
    public class UserGroupMembership
    {
        public string UserId { get; set; }
        public string GroupId { get; set; }

        public UserInfo User { get; set; }
        public UserGroup UserGroup { get; set; }
    }
}
