namespace Vendors.Api;

public static class VendorApiExtensions
{
    extension(IEndpointRouteBuilder endpoints)
    {
        public IEndpointRouteBuilder MapVendorApiEndpoints()
        {
            var group = endpoints.MapGroup("/vendors")
                .WithDescription("Vendor List And Lookup")
                .WithDisplayName("Vendor List");

            group.MapGet("", GetVendors).WithDisplayName("Vendor List").WithDescription("Get the list of vendors");

            group.MapGet("{id:guid}", GetVendorById)
                .WithDisplayName("Vendor By Id")
                .WithDescription("Get a vendor by its unique identifier");

            return endpoints;
        }

        static async Task<IResult> GetVendors(string? apiKey)
        {
            if (apiKey is null)
            {
                return TypedResults.BadRequest("API_KEY is required");
            }

            var lastThree = apiKey.Length >= 3 ? apiKey[^3..] : apiKey;
            if (!int.TryParse(lastThree, out var delaySeconds))
            {
                return TypedResults.BadRequest("API_KEY must end with three digits");
            }

            await Task.Delay(delaySeconds * 100);
            var response = new
            {
                Note = "This is fake data for a classroom example", Vendors = StaticVendorList.Vendors
            };

            return TypedResults.Ok(response);
        }

        static async Task<IResult> GetVendorById(Guid id, string? apiKey)
        {
            // get the last three characters of the API key
            // if they are an integer, delay that many seconds
            // if they are not return a 400 bad request
            if (apiKey is null)
            {
                return TypedResults.BadRequest("API_KEY is required");
            }

            var lastThree = apiKey.Length >= 3 ? apiKey[^3..] : apiKey;
            if (!int.TryParse(lastThree, out var delaySeconds))
            {
                return TypedResults.BadRequest("API_KEY must end with three digits");
            }

            await Task.Delay(delaySeconds * 100);

            var vendor = StaticVendorList.Vendors.FirstOrDefault(v => v.Id == id);

            if (vendor == null)
            {
                return TypedResults.NotFound();
            }

            return TypedResults.Ok(vendor);
        }
    }
}