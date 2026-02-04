
using Marten;
using Microsoft.OpenApi;
using Vendors.Api.Vendors;
using Wolverine;
using Wolverine.Marten;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.AddNpgsqlDataSource("vendors-db");
// IMessageBus
builder.UseWolverine(options =>
{
    options.Policies.UseDurableLocalQueues();
});

// Add Marten - with a database - for the events, because these need to be durable.
builder.Services.AddMarten(options =>
{

}).IntegrateWithWolverine()
.UseLightweightSessions()
.UseNpgsqlDataSource();


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



app.MapOpenApi();

app.MapVendorEndpoints();
app.MapDefaultEndpoints();


app.Run();