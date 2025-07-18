using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataPatrolTask.Models
{
    public class UserRequest
    {
        [Key]
        public long RequestId { get; set; }
        public string RequestedBy { get; set; }
        [ForeignKey(nameof(RequestedUser))]
        public string RequestedUserUserId { get; set; }
        public UserInfo RequestedUser { get; set; }

        public DateTime RequestDateTime { get; set; } = DateTime.UtcNow;
        public int RequestCode { get; set; }
        public string Description { get; set; }
        public RequestStatus Status { get; set; }
        public DateTime? CompletionDateTime { get; set; }
    }

    public enum RequestStatus
    {
        Draft = 0,
        InReview = 1,
        Approved = 2,
        Rejected = 3,
        Error = 4
    }
}
