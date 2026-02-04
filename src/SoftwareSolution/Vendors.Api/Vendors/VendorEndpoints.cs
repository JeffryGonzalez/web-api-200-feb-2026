using Wolverine;

namespace Vendors.Api.Vendors;

public static class VendorEndpoints
{

    extension(IEndpointRouteBuilder endpoints)
    {
        public IEndpointRouteBuilder MapVendorEndpoints()
        {
            var group = endpoints.MapGroup("vendors");

            // Get All The Vendors (Read Model)

            // A way to add vendors
            group.MapPost("/", AddingVendors.Add);
            group.MapDelete("{id:guid}", async (Guid id, IMessageBus bus) =>
            {
                await bus.PublishAsync(new RemoveAVendor(id));
                return;
            });
            // A way to remove vendors


            return group;
        }
    }
}
