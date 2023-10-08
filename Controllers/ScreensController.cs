
using hesapkimdeapi.Models;
using hesapkimdeapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace hesapkimdeapi.Controllers;

[ApiController]
[Route("api/")]
public class ScreensController : ControllerBase
{
    private readonly IScreenService _screensService;
    public ScreensController(IScreenService screenService)
    {
        _screensService = screenService;
    }
    [HttpGet("get-screens")]
    public IActionResult GetScreens()
    {
        var result = _screensService.GetScreens();
        return Ok(result);
    }
    [HttpPost("add-screen")]
    public IActionResult AddScreen(Screen screen)
    {
        var result = _screensService.AddScreen(screen);
        if(result == null) return BadRequest("There occured an error while adding screen");
        return Ok(result);
    }
    [HttpGet("get-screen/{id}")]
    public IActionResult GetScreen(int id)
    {
        var result = _screensService.GetScreen(id);
        if(result == null) return BadRequest("There is no matching screen you are looking for");
        return Ok(result);
    }
    [HttpPut("edit-screen/{id}")]
    public IActionResult UpdateScreen(int id, Screen screen)
    {
        var result = _screensService.UpdateScreen(id, screen);
        if(result == null) return BadRequest("There occured an error while updating screen");
        return Ok(result);
    }
    [HttpDelete("delete-screen/{id}")]
    public IActionResult DeleteScreen(int id)
    {
        var result = _screensService.DeleteScreen(id);
        if(result == null) return BadRequest("There occured an error while deleting screen");
        return Ok(result);
    }
}