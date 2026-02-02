var builder = WebApplication.CreateBuilder(args); // Hey Microsoft, give me the stuff you think I'll need.



// Add services to the container.

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

app.Run();
