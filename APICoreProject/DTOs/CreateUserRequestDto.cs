using System.ComponentModel.DataAnnotations;

namespace APICoreProject.DTOs
{
    public class CreateUserRequestDto
    {
        [Required]
        public string UserId { get; set; }  
        public int RequestCode { get; set; }
        public string Description { get; set; }
    }
}
