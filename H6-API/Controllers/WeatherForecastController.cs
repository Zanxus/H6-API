using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using static Duende.IdentityServer.IdentityServerConstants;

namespace H6_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Route("localApi")]
    [Authorize(LocalApi.PolicyName)]
    public class DiscoveryDocumentController : ControllerBase
    {

        [HttpGet(Name = "GetDiscoveryDocument")]
        public async Task<IActionResult> Get()
        {
            var client = new HttpClient();
            DiscoveryDocumentResponse disco = await client.GetDiscoveryDocumentAsync("http://localhost:5001");
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return BadRequest(disco.Json);
            }
            return Ok(disco.Json);
        }
    }
}