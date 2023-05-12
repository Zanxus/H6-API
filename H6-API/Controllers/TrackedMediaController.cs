using H6_API.Domain.DTO;
using H6_API.Domain.Entites;
using H6_API.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace H6_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackedMediaController : ControllerBase
    {
        private readonly ITrackedMediaService _trackedMediaService;
        private readonly IUserService _userService;

        public TrackedMediaController(ITrackedMediaService trackedMediaService, IUserService userService)
        {
            _trackedMediaService = trackedMediaService;
            _userService = userService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAllByUserId(string userId)
        {
            var trackedMedia = await _trackedMediaService.GetAllByUserIdAsync(userId);

            List<TrackedMediaDTO> result = new List<TrackedMediaDTO>();
            foreach (var media in trackedMedia)
            {
                result.Add(new TrackedMediaDTO { Id = media.Id, ImdbId = media.ImdbId, TrackedState = media.TrackedState, UserId = media.ApplicationUser?.Id });
            }

            if (trackedMedia == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("imdb/{imdbId}")]
        public async Task<IActionResult> GetByImdbId(string imdbId)
        {
            var trackedMedia = await _trackedMediaService.GetByImdbIdAsync(imdbId);

            if (trackedMedia == null)
            {
                return NotFound();
            }

            return Ok(trackedMedia);
        }

        [HttpPost()]
        public async Task<IActionResult> Post(TrackedMediaDTO trackedMedia)
        {

            ApplicationUser user = _userService.GetUser(trackedMedia.UserId).Result;
            if (user == null)
            {
                return NotFound("User Not found");
            }
           var mappedtrackedMedia = new TrackedMedia
           {
               ApplicationUser = user,
               ImdbId = trackedMedia.ImdbId,
               TrackedState = trackedMedia.TrackedState
           };

            _trackedMediaService.Post(mappedtrackedMedia);

            return Ok(trackedMedia);
        }


        [HttpPut("imdb/{imdbId}")]
        public async Task<IActionResult> Update(TrackedMedia trackedMedia)
        {
             _trackedMediaService.Put(trackedMedia);

            if (trackedMedia == null)
            {
                return NotFound();
            }

            return Ok(trackedMedia);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _trackedMediaService.Delete(id);
            return Ok(id);
        }

        [HttpGet("state/{state}")]
        public async Task<IActionResult> GetCountByState(string state)
        {
            if (!Enum.TryParse<TrackedState>(state, out var trackedState))
            {
                return BadRequest("Invalid state parameter");
            }

            var count = await _trackedMediaService.GetCountByStateAsync(trackedState);

            return Ok(count);
        }
    }
}
