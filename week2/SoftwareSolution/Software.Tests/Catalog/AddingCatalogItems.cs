using Alba;
using Software.Api.Catalog;

namespace Software.Tests.Catalog;
public class AddingCatalogItems
{
    [Fact]
    public async Task AddingAnItemToCatalogAsync()
    {
        var host = await AlbaHost.For<Program>();
        var request = new CatalogCreateModel
        {
            Title = "Rider",
            Vendor = "Jetrains",
            IsOpenSource = false
        };
        var response = new CatalogResponseModel
        {
            Id = Guid.Empty,
            Title = "Rider",
            Vendor = "Jetrains",
            IsOpenSource = false
        };
    }

}
