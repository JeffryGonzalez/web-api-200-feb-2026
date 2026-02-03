namespace Software.Api.BackingApis;

public class VendorsApi(HttpClient client, IConfiguration provider)
{
    public async Task<bool> IsValidVendorAsync(Guid vendorId)
    {
        var apikey = provider.GetValue<string>("VENDOR_API_KEY");
        var response = await client.GetAsync($"/vendors/{vendorId}?apiKey={apikey}");
        return response.IsSuccessStatusCode;
    }
}