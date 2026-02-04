
using Microsoft.OpenApi;
using Scalar.AspNetCore;
using Vendors.Api;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();
builder.Services.AddOpenApi(config =>
{
    config.AddDocumentTransformer((doc, ctx, ct) =>
    {
        doc.Info = new OpenApiInfo()
        {
            Title = "Vendors API for Classroom Training",
            Description =
                "This API provides a list of vendors and allows lookup by unique identifier. It is intended for use in classroom training scenarios. \n\n The API Key can be anything that ends in three integers. Those integers are multiplied by 100 and the result is delayed by that number of milliseconds.",
        };
        return Task.CompletedTask;
    });
});

var app = builder.Build();


app.MapVendorApiEndpoints();
app.MapOpenApi();
app.MapScalarApiReference(options =>
{
    options.Theme = ScalarTheme.BluePlanet;
    options.Title = "Vendors API Reference";
    
});

app.MapDefaultEndpoints();

app.MapGet("/", () => Results.Redirect("/scalar")).WithDescription("Redirect to API Reference").WithDisplayName("Home Redirect");
app.Run();