using Microsoft.AspNetCore.Mvc;
using UnitConversion.Models;
using UnitConversion.Services;

namespace UnitConversion.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ConversionsController : ControllerBase
{
    private readonly IConversionService _conversionService;

    public ConversionsController(
        IConversionService conversionService)
    {
        _conversionService = conversionService;
    }

    [HttpPost]
    public ActionResult<ConversionResponse> Convert(
        [FromBody] ConversionRequest request)
    {
        try
        {
            var result = _conversionService.Convert(request);
            return Ok(result);
        }
        catch (KeyNotFoundException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpGet("units")]
    public ActionResult<IEnumerable<UnitDefinition>> GetUnits()
    {
        return Ok(_conversionService.GetUnits());
    }
}