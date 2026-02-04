using Marten;
using Wolverine;
using InternalMessages = Messages.SoftwareCenter;

namespace Vendors.Api.Vendors;

public static class VendorHandler
{
    public static async Task Handle(CreateAVendor command, IDocumentSession session, IMessageBus bus)
    {
        // do everything there that you would need to do when a vendor is created.
        // or just return another command, and they will "cascade"

       // await Task.Delay(30000); // One Minute Delay to simulate long running process
        if(command.Name == "Bad Vendor")
        {
            throw new Exception("This is a bad vendor, we can't create it");
        }

        // "topic"
        session.Events.StartStream(command.Id, new VendorCreated(command.Id, command.Name));
        
        await bus.PublishAsync(new InternalMessages.VendorCreated(command.Id, command.Name));

        await session.SaveChangesAsync();
       
    }

    public static async Task Handle(RemoveAVendor command, IDocumentSession session, IMessageBus bus)
    {
        await bus.PublishAsync(new InternalMessages.VendorDeactivated(command.Id));
        session.Events.Append(command.Id, new VendorDeactivated(command.Id));
    }
}
