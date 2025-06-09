using Apbd_test2.Dto.Request;
using Apbd_test2.Service;
using Microsoft.AspNetCore.Mvc;

namespace Apbd_test2.Controller;

[Controller]
[Route("/api/track-races")]
public class TrackRacesController : ControllerBase
{
    
    private readonly IDbService _service;

    public TrackRacesController(IDbService service)
    {
        _service = service;
    }
    
    [HttpPost("participants")]
    public async Task<IActionResult> addNewTrackParticipation([FromBody] RequestDto request)
    {
        try
        {
            var res = await _service.addNewParticipation(request);
            return Ok(res);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
}