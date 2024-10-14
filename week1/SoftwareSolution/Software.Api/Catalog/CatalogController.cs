

using Microsoft.AspNetCore.Mvc;

namespace Software.Api.Catalog;

[ApiController]
public class CatalogController : ControllerBase
{
    [HttpPost("/catalog")]
    public async Task<ActionResult> AddSoftwareToCatalogAsync()

    {
        return Ok();
    }
}
