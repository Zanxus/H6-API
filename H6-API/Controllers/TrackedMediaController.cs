using H6_API.Domain.Entites;
using H6_API.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace H6_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackedMediaController : ControllerBase
    {
        private readonly ITrackedMediaService _service;

        public TrackedMediaController(ITrackedMediaService service)
        {
            _service = service;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAllByUserId(string userId)
        {
            var trackedMedia = await _service.GetAllByUserIdAsync(userId);

            if (trackedMedia == null)
            {
                return NotFound();
            }

            return Ok(trackedMedia);
        }

        [HttpGet("imdb/{imdbId}")]
        public async Task<IActionResult> GetByImdbId(string imdbId)
        {
            var trackedMedia = await _service.GetByImdbIdAsync(imdbId);

            if (trackedMedia == null)
            {
                return NotFound();
            }

            return Ok(trackedMedia);
        }

        [HttpPut("imdb/{imdbId}")]
        public async Task<IActionResult> Update(TrackedMedia trackedMedia)
        {
             _service.Put(trackedMedia);

            if (trackedMedia == null)
            {
                return NotFound();
            }

            return Ok(trackedMedia);
        }

        [HttpDelete()]
        public async Task<IActionResult> Delete(TrackedMedia trackedMedia) {
            if (trackedMedia == null)
            {
                return NotFound();
            }
            _service.Delete(trackedMedia);

            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(string id)
        {
            _service.get
            if (trackedMedia == null)
            {
                return NotFound();
            }
            _service.Delete(trackedMedia);

            return Ok();
        }

        [HttpGet("state/{state}")]
        public async Task<IActionResult> GetCountByState(string state)
        {
            if (!Enum.TryParse<TrackedState>(state, out var trackedState))
            {
                return BadRequest("Invalid state parameter");
            }

            var count = await _service.GetCountByStateAsync(trackedState);

            return Ok(count);
        }
    }
}
