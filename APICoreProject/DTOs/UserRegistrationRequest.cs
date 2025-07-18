namespace APICoreProject.DTOs
{
   
    public class UserRegistrationRequest
    {
        public string Username { get; set; }
    }

    
    public class UserRegistrationResponse
    {
        public string UserId { get; set; }
        public bool IsDisabled { get; set; }
    }
}
