using System.ComponentModel.DataAnnotations;
using Marten;
using Microsoft.AspNetCore.Http.HttpResults;
using Software.Api.BackingApis;
using Software.Api.Catalog.Entities;

namespace Software.Api.Catalog.Operations;

public record CatalogItemRequest
{
    [Required, MinLength(3), MaxLength(100)]
    public string Title { get; set; } = string.Empty;
    [Required]
    public Guid VendorId { get; set; }

}

public record CatalogItemResponse
{
    public required Guid Id { get; set; }
    public required string Title { get; set; } = string.Empty;
    public required Guid VendorId { get; set; }
}

public static class AddingItem
{
    public static async Task< Results<Ok<CatalogItemResponse>, BadRequest<string>>> 
        Post(CatalogItemRequest req, IDocumentSession session, CancellationToken token)
    {

        // This is a good use of a cancellation token, because if the client disconnects
        // we don't need to keep working on this request.
       var doesVendorExist =await  session.Query<VendorDocument>()
           .AnyAsync(v => v.Id == req.VendorId, token: token); 

        if (doesVendorExist)
        {
            // todo: persist to database
            var fakeResponse = new CatalogItemResponse()
            {
                Id = Guid.NewGuid(),
                Title = req.Title,
                VendorId = req.VendorId
            };
            var entity = new CatalogItem()
            {
                Id = Guid.NewGuid(),
                Title = req.Title,
                VendorId = req.VendorId
            };
            session.Store(entity);
            // not using the token here, because I don't want to cancel this
            // if the user dropped the connection. They *think* the work is done,
            // and their son is scheduled for the thing they just registered them for,
            // so to speak.
            await session.SaveChangesAsync();
            return TypedResults.Ok(new CatalogItemResponse()
            {
                Id = entity.Id,
                Title = entity.Title,
                VendorId = entity.VendorId  
            });
        } else
        {
            return TypedResults.BadRequest("No Vendor With That Id");
        }
    }
}