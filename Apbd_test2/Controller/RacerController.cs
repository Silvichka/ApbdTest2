using Apbd_test2.Service;
using Microsoft.AspNetCore.Mvc;

namespace Apbd_test2.Controller;

[Controller]
[Route("/api/racers")]
public class RacerController : ControllerBase
{
    
    private readonly IDbService _service;

    public RacerController(IDbService service)
    {
        _service = service;
    }

    [HttpGet("{id}/participation")]
    public async Task<IActionResult> getRacerParticipations(int id)
    {
        try
        {
            var res = await _service.getRacerParticipation(id);
            return Ok(res);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
    
}