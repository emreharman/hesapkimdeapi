using Microsoft.AspNetCore.Mvc;
using hesapkimdeapi.Services;
using hesapkimdeapi.Models;

namespace hesapkimdeapi.Controllers;

[ApiController]
[Route("api/")]
public class AdTypesController : ControllerBase
{
    private readonly IAdTypeService _adTypesService;
    public AdTypesController(IAdTypeService adTypeService)
    {
        _adTypesService = adTypeService;
    }

    [HttpGet("get-adTypes")]
    public  IActionResult GetAdTypes()
    {
        var result =  _adTypesService.GetAdTypes();
        if(result == null) return BadRequest("There is occured an error");
        return Ok(result);
    }
    [HttpPost("add-adType")]
    public IActionResult AddAdType(AdType adType)
    {
        var result = _adTypesService.AddAdType(adType);
        if(result == null) return BadRequest("There is occured an error");
        return Ok(result);
    }
    [HttpGet("get-adType/{id}")]
    public IActionResult GetAdType(int id)
    {
        var result = _adTypesService.GetAdType(id);
        if(result == null) BadRequest("There is no ad type matching you are looking for");
        return Ok(result);
    }
    [HttpPut("edit-adType/{id}")]
    public IActionResult UpdateAdType(int id, AdType adType)
    {
        var result = _adTypesService.UpdateAdType(id, adType);
        if(result == null) return BadRequest("There is occured an error");
        return Ok(result);
    }
    [HttpDelete("delete-adType/{id}")]
    public IActionResult DeleteAdType(int id)
    {
        var result = _adTypesService.DeleteAdType(id);
        if(result == null) BadRequest("There is occured an error");
        return Ok(result);
    }
}
