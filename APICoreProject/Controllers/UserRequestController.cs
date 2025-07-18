using APICoreProject.DTOs;
using DataPatrolTask.DataMigration;
using DataPatrolTask.Models;
using DataPatrolTask.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataPatrolTask.Controllers
{
    [ApiController]
    [Route("request")]
    public class UserRequestController : ControllerBase
    {
        private readonly IUserRequestRepository _requestRepo;
        private readonly AppDbContext _context; 

        public UserRequestController(IUserRequestRepository requestRepo ,IUserInfoRepository userRepo ,AppDbContext context)
        {
            _requestRepo = requestRepo;
            _context = context;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateRequest([FromBody] CreateUserRequestDto dto)
        {
            var user = await _context.UserInfos
                .FirstOrDefaultAsync(u => u.UserId == dto.UserId);

            if (user == null)
                return NotFound(new { message = "User not found." });

            var request = new UserRequest
            {
                RequestedBy = user.UserId,
                RequestedUser = user,
                RequestCode = dto.RequestCode,
                Description = dto.Description,
                Status = RequestStatus.Draft
            };

            var createdRequest = await _requestRepo.CreateAsync(request);

            return Ok(new { RequestId = createdRequest.RequestId });
        }

        [HttpPost("summary")]
        public async Task<IActionResult> GetRequestSummary([FromBody] UserRequestSummaryDto dto)
        {
            var user = await _context.UserInfos
                .FirstOrDefaultAsync(u => u.UserId == dto.UserId);

            if (user == null)
                return NotFound(new { message = "User not found." });

            var summary = await _context.UserRequests
                .Where(r => r.RequestedBy == dto.UserId)
                .GroupBy(r => r.Status)
                .Select(g => new
                {
                    Status = g.Key.ToString(),
                    Count = g.Count()
                })
                .ToListAsync();

            // Count All Status
            var allStatuses = Enum.GetNames(typeof(RequestStatus));
            var result = new Dictionary<string, int>();

            foreach (var status in allStatuses)
            {
                result[status] = summary.FirstOrDefault(s => s.Status == status)?.Count ?? 0;
            }

            return Ok(result);
        }

    }
}
