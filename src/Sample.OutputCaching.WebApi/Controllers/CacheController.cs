using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace Sample.OutputCaching.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CacheController : ControllerBase
{
    private static readonly string[] Countries =
    {
        "Argentina", "Australia", "Brazil", "Colombia", "Egypt", "Italy", "Mexico", "Russia", "Ukraine", "Uruguay"
    };

    [HttpGet("countries")]
    [OutputCache]
    public IActionResult GetCountries()
    {
        var result = new
        {
            Date = DateTime.Now,
            Countries
        };

        return Ok(result);
    }
}
