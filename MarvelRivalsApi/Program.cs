using MarvelRivals.Data;
using MarvelRivals.Data.Repositories.Heroes;
using MarvelRivals.Data.Repositories.Maps;
using MarvelRivals.Services.GameMaps;
using MarvelRivals.Services.Heroes;
using MarvelRivals.Services.Managers;
using MarvelRivalsApi.Data.Repositories.Maps;
using MarvelRivalsApi.Data.Repositories.Matchhistory;
using MarvelRivalsApi.Data.Repositories.MatchHistory;
using MarvelRivalsApi.Services.Managers;
using MarvelRivalsApi.Services.MatchHistory;
using MarvelRivalsApi.Services.MatchHistoryService;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// --- Configure Port for Railway ---
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

// --- Configure CORS ---
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins(
            "http://localhost:4200", "https://marvelrivalsui.vercel.app", "https://marvelrivalsui-anthonybturners-projects.vercel.app"    // Local dev
        )
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

// --- Add Controllers and Swagger ---
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.CustomSchemaIds(type => type.FullName);
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Marvel Rivals API",
        Version = "v1",
        Description = "Backend API for Marvel Rivals data (Heroes, Maps, Match History)"
    });
});

// --- Configure Database ---
var rawConnString = builder.Configuration.GetConnectionString("DefaultConnection");

if (string.IsNullOrEmpty(rawConnString))
{
    Console.WriteLine("DefaultConnection not found in config, building manually from environment vars...");
    rawConnString = "Host=<SERVER_HOST>;Port=<SERVER_PORT>;Database=<SERVER_DB>;Username=<SERVER_USER>;Password=<SERVER_PASSWORD>";
}

var baseConnectionString = rawConnString
    .Replace("<SERVER_HOST>", Environment.GetEnvironmentVariable("SERVER_HOST") ?? "localhost")
    .Replace("<SERVER_DB>", Environment.GetEnvironmentVariable("SERVER_DB") ?? "marvelrivalsdb")
    .Replace("<SERVER_USER>", Environment.GetEnvironmentVariable("SERVER_USER") ?? "postgres")
    .Replace("<SERVER_PASSWORD>", Environment.GetEnvironmentVariable("SERVER_PASSWORD") ?? "password")
    .Replace("<SERVER_PORT>", Environment.GetEnvironmentVariable("SERVER_PORT") ?? "5432");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(baseConnectionString));

// --- Register Repositories & Services ---
builder.Services.AddScoped<IHeroesService, HeroesService>();
builder.Services.AddScoped<IGameMapsService, GameMapsService>();
builder.Services.AddScoped<IMatchHistoryService, MatchHistoryService>();

builder.Services.AddScoped<IGameMapsRepository, GameMapsRepository>();
builder.Services.AddScoped<IHeroesRepository, HeroesRepository>();
builder.Services.AddScoped<IMatchHistoryRepository, MatchHistoryRepository>();

builder.Services.AddScoped<GameMapsManager>();
builder.Services.AddScoped<HeroesManager>();
builder.Services.AddScoped<MatchHistoryManager>();

// --- Configure HttpClients for Services ---
string apiBaseUrl = builder.Configuration["ApiSettings:BaseUrl"] ?? "";
builder.Services.AddHttpClient<IHeroesService, HeroesService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
});
builder.Services.AddHttpClient<IGameMapsService, GameMapsService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
});
builder.Services.AddHttpClient<IMatchHistoryService, MatchHistoryService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
});

var app = builder.Build();

// --- Swagger UI ---
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Marvel Rivals API v1");
});

// --- Middlewares ---
app.UseRouting();
app.UseCors("AllowAngularApp");  // <-- Must be BEFORE UseAuthorization
app.UseAuthorization();

// --- Map Controllers & Healthcheck ---
app.MapControllers();
app.MapGet("/health", () => Results.Ok("✅ Marvel Rivals API is running"));

// --- Run App ---
app.Run();
