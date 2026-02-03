using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Software.Api.Catalog.Operations;

public record CatalogItemRequest
{
    [Required, MinLength(3), MaxLength(100)]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string VendorId { get; set; } = string.Empty;

}

public record CatalogItemResponse
{
    public required Guid Id { get; set; }
    public required string Title { get; set; } = string.Empty;
    public required string VendorId { get; set; } = string.Empty;
}

public static class AddingItem
{
    public static Results<Ok<CatalogItemResponse>, BadRequest<string>> Post(CatalogItemRequest req)
    {
     
        // todo: validate vendor id against vendor api
        // todo: persist to database
        var fakeResponse = new CatalogItemResponse()
        {
            Id = Guid.NewGuid(),
            Title = req.Title,
            VendorId = req.VendorId
        };
        return TypedResults.Ok(fakeResponse);
    }
}