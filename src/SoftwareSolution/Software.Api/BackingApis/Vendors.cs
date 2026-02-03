namespace Software.Api.BackingApis;

public class Vendors(HttpClient client, IConfiguration config)
{
    public async Task<Boolean> CheckIfVendorExistsAsync(Guid vendorId, CancellationToken token)
    {
        var apiKey = config.GetValue<string>("VENDOR_API_KEY"); // throwing here is too late maybe.
        // The Url to to API - don't set that here. That's in program.cs.
        var response = await client.GetAsync($"/vendors/{vendorId}?apiKey={apiKey}");
        return response.IsSuccessStatusCode;
    
    }
}
