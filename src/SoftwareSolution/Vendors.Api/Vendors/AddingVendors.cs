using Wolverine;

namespace Vendors.Api.Vendors;

public record VendorCreateModel(string Name);
public static class AddingVendors
{
    public static async Task<IResult> Add(VendorCreateModel req, IMessageBus bus)
    {
        // bridge between HTTP and a command. 
        var command = new CreateAVendor(Guid.NewGuid(), req.Name);
        await bus.PublishAsync(command);
        return TypedResults.Created($"/vendors/{command.Id}");
    }
 }
