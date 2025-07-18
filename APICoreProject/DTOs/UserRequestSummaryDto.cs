using System.ComponentModel.DataAnnotations;

namespace APICoreProject.DTOs
{
    public class UserRequestSummaryDto
    {
        [Required]
        public string UserId { get; set; }
    }
}
