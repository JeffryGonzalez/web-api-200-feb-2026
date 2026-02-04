namespace Software.Api.Catalog.Entities;

public class CatalogItem
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public Guid VendorId { get; set; }
}