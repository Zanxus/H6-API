﻿using H6_API.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace H6_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Route("localApi")]
    public class OMDBController : ControllerBase
    {
        private readonly IOMDBService oMDBService;
        private readonly ILogger logger;

        public OMDBController(IOMDBService oMDBService, ILogger logger)
        {
            this.oMDBService = oMDBService;
            this.logger = logger;
        }

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
                logger.LogError(ex, "Error searching for media.");

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while searching for media.");
            }
        }
    }
}
