using Marten;

namespace Vendors.Api.Vendors;

public static class VendorHandler
{
    public static async Task Handle(CreateAVendor command, IDocumentSession session)
    {
        // do everything there that you would need to do when a vendor is created.
        // or just return another command, and they will "cascade"

        // "topic"
        session.Events.StartStream(command.Id, new VendorCreated(command.Id, command.Name));

        await session.SaveChangesAsync();

    }

    public static async Task Handle(RemoveAVendor command, IDocumentSession session)
    {
        session.Events.Append(command.Id, new VendorDeactivated(command.Id));
    }
}
