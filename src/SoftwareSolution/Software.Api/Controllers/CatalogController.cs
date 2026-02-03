using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Software.Api.Controllers;

//public class CatalogController : ControllerBase
//{
//    [HttpPost("catalog")]
//    public async Task<ActionResult> AddItemToCatalogAsync([FromBody] CatalogItemRequest request)
//    {
//        // have to await
//        return Ok(request); 
//    }
//}

public static class CatalogApiExtensions
{
    extension(IEndpointRouteBuilder endpoints)
    {
        public IEndpointRouteBuilder MapCatalogRoutes()
        {
            var group = endpoints.MapGroup("catalog")
                .WithDescription("All Things Catalog Related");

            group.MapPost("", async (CatalogItemRequest req) =>
            {
                return TypedResults.Ok(req);
            });
               
            return endpoints;
        }
    }
}

public record CatalogItemRequest
{
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string VendorId { get; set; } = string.Empty;
}