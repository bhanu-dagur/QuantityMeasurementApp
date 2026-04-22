using HistoryService.Models;
using HistoryService.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HistoryService.Controllers
{
    [ApiController]
    [Route("api/history")]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryRepository _repo;

        public HistoryController(IHistoryRepository repo)
        {
            _repo = repo;
        }


        // POST /api/history
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] SaveHistoryDTO dto)
        {
            var history = new MeasurementHistory
            {
                UserId     = dto.UserId,
                InputValue1 = dto.InputValue1,
                InputUnit1  = dto.InputUnit1,
                InputValue2 = dto.InputValue2,
                InputUnit2  = dto.InputUnit2,
                TargetUnit  = dto.TargetUnit,
                Operation   = dto.Operation,
                ResultValue = dto.ResultValue,
                ResultUnit  = dto.ResultUnit
            };

            await _repo.SaveAsync(history);

            return Ok(new { success = true, message = "History saved." });
        }

        // GET /api/history/mine        
        [Authorize]
        [HttpGet("mine")]
        public async Task<IActionResult> GetMyHistory()
        {
            // take userId from JWT token
            string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
                return Unauthorized(new { success = false, message = "Login required." });

            var history = await _repo.GetByUserIdAsync(userId);

            return Ok(new
            {
                success = true,
                count   = history.Count,
                data    = history
            });
        }

        // GET /api/history/user/{userId}
        // Specific user history (internal use — ApiGateway se)
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetHistoryByUser(string userId)
        {
            var history = await _repo.GetByUserIdAsync(userId);
            return Ok(new { success = true, count = history.Count, data = history });
        }
    }
}
