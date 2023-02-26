using Microsoft.AspNetCore.Mvc;

namespace MusicCloud.Server.Music;

[ApiController]
[Route("api/[controller]")]
public class MusicController : ControllerBase
{
    private IMusicManager musicManager;

    public MusicController(IMusicManager musicManager) {
        this.musicManager = musicManager;
    }

    [HttpGet]
    public ActionResult Hello()
    {
        return Ok("Hello world");
    }
    
    [HttpPost]
    public async Task<ActionResult> UploadMusic()
    {
        var files = Request.Form.Files;

        await this.musicManager.SaveFiles(files, 1);

        return Ok();
    }
}