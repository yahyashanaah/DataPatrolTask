using Microsoft.AspNetCore.Mvc;
using DataPatrolTask.Models;
using DataPatrolTask.Services.Interfaces;
using APICoreProject.DTOs;
[ApiController]
[Route("[controller]")]
public class UserInfoController : ControllerBase
{
    private readonly IUserInfoRepository _userRepo;

    public UserInfoController(IUserInfoRepository userRepo)
    {
        _userRepo = userRepo;
    }

    [HttpPost("/reg")]
    public async Task<IActionResult> Register([FromBody] UserRegistrationRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Username))
        {
            return BadRequest("Username is required.");
        }

        string baseUserId = request.Username.Trim();
        string finalUserId = baseUserId;
        int counter = 1;

        // Check for duplicates and increment if needed
        while (await UsernameExistsAsync(finalUserId))
        {
            finalUserId = $"{baseUserId}_{counter:D2}";
            counter++;
        }

        var user = new UserInfo
        {
            UserId = finalUserId,
            Username = baseUserId,
            IsEnabled = true,
            CreatedDateTime = DateTime.UtcNow,
            TenantId = "default"
        };

        await _userRepo.CreateAsync(user);

        var response = new UserRegistrationResponse
        {
            UserId = user.UserId,
            IsDisabled = !user.IsEnabled
        };

        return Ok(response);
    }

    
    private async Task<bool> UsernameExistsAsync(string userId)
    {
        return await _userRepo.ExistsByUserIdAsync(userId);
    }
}
