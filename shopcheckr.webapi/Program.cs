using MediatR;
using Microsoft.AspNetCore.Mvc;
using shopcheckr.application.Queries.AnalyzeShopMentions;
using shopcheckr.domain.Enums;
using shopcheckr.infrastructure; // Ensure this namespace is correct and the library is referenced

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Ensure the AddInfrastructure method is implemented and accessible
builder.Services.AddInfrastructure();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.MapStaticAssets();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/api/analyze", async (
    [FromQuery] string shopHandle,
    [FromQuery] PlatformType? platform,
    IMediator mediator) =>
{
    if (string.IsNullOrWhiteSpace(shopHandle))
        return Results.BadRequest("Shop handle is required.");

    if (platform is null)
        return Results.BadRequest("Platform is required.");

    var query = new AnalyzeShopMentionsQuery(shopHandle, platform.Value);
    var result = await mediator.Send(query);
    return Results.Ok(result);
})
.WithName("AnalyzeShopMentions")
.WithDescription("Analyzes social media mentions of a shop and returns sentiment and trust score.")
.Produces<AnalyzeShopMentionsResult>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status400BadRequest);



app.MapFallbackToFile("/index.html");

app.Run();
