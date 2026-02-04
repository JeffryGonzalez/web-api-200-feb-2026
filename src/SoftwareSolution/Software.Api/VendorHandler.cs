using Marten;

namespace Software.Api;

public class VendorDocument
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;

    public static VendorDocument Create(Messages.SoftwareCenter.VendorCreated message)
    {
        return new VendorDocument()
        {
            Id = message.Id,
            Name = message.Name
        };
    }
}
public static class VendorHandler
{
    public static async Task Handle(Messages.SoftwareCenter.VendorCreated message, IDocumentSession session)
    {
        session.Store(VendorDocument.Create(message));
        await session.SaveChangesAsync();
    }

    public static async Task Handle(Messages.SoftwareCenter.VendorDeactivated message, IDocumentSession session)
    {

      session.Delete<VendorDocument>(message.Id);
      await session.SaveChangesAsync();
    }
}