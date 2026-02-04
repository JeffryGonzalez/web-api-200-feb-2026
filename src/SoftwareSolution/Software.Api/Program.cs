using Marten;
using Software.Api.BackingApis;
using Software.Api.Catalog;
using Wolverine;
using Wolverine.Marten;
using Wolverine.Nats;

var builder = WebApplication.CreateBuilder(args); // Hey Microsoft, give me the stuff you think I'll need.
builder.AddNpgsqlDataSource("software-db"); // service location
builder.AddServiceDefaults(); // Add our "standard" resiliency, open telemetry, all that.
// ASPNETCORE_ENVIRONMENT=Tacos
// The last place is the actual environment variables on the machine.


//var salesDiscountAmount = builder.Configuration.GetValue<decimal>("sales-discount");
//var connectionString = builder.Configuration.GetConnectionString("software-db") ??
//    throw new Exception("Cannnot start without a connection string");

// Add services to the container.
// TypedHttpClient

//var vendorApi = builder.Configuration.GetValue<string>("VENDORS_API") ?? throw new Exception("No Vendor Url");

builder.Services.AddHttpClient<Vendors>(client =>
{
    client.BaseAddress = new Uri("https://vendors-api");
}); // todo: throw a sample of proxy config.


builder.Services.AddValidation(); // This is new. Do code gen for validation.
builder.Services.AddProblemDetails(); // I'll talk about this in a second.

builder.UseWolverine(options =>
{
    options.UseNats(builder.Configuration.GetConnectionString("broker") ??
            throw new Exception("No NATS connection string configured"))
.AutoProvision()
.UseJetStream(js =>
{
    js.MaxDeliver = 5;
    js.AckWait = TimeSpan.FromSeconds(30);
})

.DefineStream("VENDORS", stream =>
    stream.WithSubject("vendor.>")
        .WithLimits(maxMessages: 5_000, maxAge: TimeSpan.FromDays(5))
        //.WithReplicas(3)
        .EnableScheduledDelivery());

    /* options.ListenToNatsSubject("people.>") // I want to see any message products.*.available.uk
    .UseJetStream("PEOPLE", "api-two");*/

    options.ListenToNatsSubject("vendor.>")
    .UseJetStream("VENDORS", "software-api");
});

builder.Services.AddMarten(config =>
    {
        // add a couple of different services to the services collection
        // one is for you, and the other is a hairy, spooky multi-threaded and thread-safe
        // service that manages the connection, SRE, etc.

    }).UseNpgsqlDataSource()
    .UseLightweightSessions()
    .IntegrateWithWolverine();


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();



// Above this line is "configuration" - mostly services
var app = builder.Build();
// after this line is "middleware" - configuration about how endpoints should be exposed

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapCatalogRoutes();

app.MapDefaultEndpoints(); // this adds the endpoints defined in the ServiceDefaults - which are mostly for health checks.
app.Run();