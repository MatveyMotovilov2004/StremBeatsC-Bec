using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;
using WebAPI.Orchestrator;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly ArtistRegistrationOrchestrator _orchestrator;

        public ArtistController(ArtistRegistrationOrchestrator orchestrator)
        {
            _orchestrator = orchestrator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateArtist(
        [FromBody] CreateArtistRequestDto request,
        CancellationToken token)
        {
            var artistId = await _orchestrator.CreateArtistAsync(request, token);

            return Ok(new { ArtistId = artistId });
        }
    }
}
