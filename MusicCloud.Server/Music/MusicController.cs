using Microsoft.AspNetCore.Mvc;

namespace MusicCloud.Music;

[ApiController]
[Route("api/[controller]")]
public class MusicController: ControllerBase {

    [HttpGet]
    public ActionResult Hello()
    {
        return Ok("Heelo world");
    }
}