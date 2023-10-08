using Microsoft.AspNetCore.Mvc;
using hesapkimdeapi.Services;
using hesapkimdeapi.Models;

namespace hesapkimdeapi.Controllers;

[ApiController]
[Route("api/")]
public class AdsController : ControllerBase
{
    private readonly IAdsService _adsService;
    public AdsController(IAdsService adsService)
    {
        _adsService = adsService;
    }
    [HttpGet("get-ads")]
    public IActionResult GetAds()
    {
        var result = _adsService.GetAds();
        return Ok(result);
    }
    [HttpPost("add-ad")]
    public IActionResult AddAd(Ad ad)
    {
        var result = _adsService.AddAd(ad);
        if(result == null) return BadRequest("Can't add the advertisemant");
        return Ok(result);
    } 
    [HttpGet("get-ad/{id}")]
    public IActionResult GetAd(int id)
    {
        var result = _adsService.GetAd(id);
        if(result == null) return BadRequest("Can not found");
        return Ok(result);
    }
    [HttpPut("edit-ad/{id}")]
    public IActionResult UpdateAd(int id, Ad ad)
    {
        var result = _adsService.UpdateAd(id, ad);
        if(result == null) return BadRequest("There occured an error while updating ad");
        return Ok(result);
    }
    [HttpDelete("delete-ad/{id}")]
    public IActionResult DeleteAd(int id)
    {
        var result = _adsService.DeleteAd(id);
        if(result == null) return BadRequest("There occured an error while deleting ad");
        return Ok(result);
    }
}
