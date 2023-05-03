using H6_API.Domain.Interfaces.Services;
using H6_API.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace H6_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Route("localApi")]
    public class OMDBController : ControllerBase
    {
        private readonly IOMDBService oMDBService;

        public OMDBController(IOMDBService oMDBService)
        {
            this.oMDBService = oMDBService;
        }
        [Authorize(Roles = UserRoles.User)]
        [HttpGet(Name = "SearchOMDB")]
        public async Task<IActionResult> Get(string search)
        {
            // Validate input
            if (string.IsNullOrEmpty(search))
            {
                return BadRequest("Search string is missing or empty.");
            }

            try
            {
                var result = await oMDBService.SearchMedia(search);

                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log error

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while searching for media.");
            }
        }
    }
}
