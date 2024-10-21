
using Marten;
using Microsoft.AspNetCore.Mvc;

namespace Software.Api.Catalog;

public class CatalogController(IDocumentSession session) : ControllerBase
{
    [HttpPost("/catalog")]
    public async Task<ActionResult> AddSoftwareToCatalogAsync([FromBody] CatalogCreateModel catalog)
    {
        var response = new CatalogResponseModel()
        {
            Id = Guid.Empty,
            IsOpenSource = catalog.IsOpenSource,
            Title = catalog.Title,
            Vendor = catalog.Vendor
        };

        var thingToSave = new CatalogEntity()
        {
            Id = Guid.Empty,
            IsOpenSource = catalog.IsOpenSource,
            Title = catalog.Title,
            Vendor = catalog.Vendor
        };

        return Ok(response);
    }
}

public class CatalogCreateModel
{
    public string Title { get; set; } = string.Empty;
    public string Vendor { get; set; } = string.Empty;
    public bool IsOpenSource { get; set; }
}

public record CatalogResponseModel
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Vendor { get; set; } = string.Empty;
    public bool IsOpenSource { get; set; }

}

public class CatalogEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Vendor { get; set; } = string.Empty;
    public bool IsOpenSource { get; set; }

}