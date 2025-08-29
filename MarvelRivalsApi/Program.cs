using MarvelRivals.Data;
using MarvelRivals.Data.Repositories.Heroes;
using MarvelRivals.Data.Repositories.Maps;
using MarvelRivals.Services.GameMaps;
using MarvelRivals.Services.Heroes;
using MarvelRivals.Services.Managers;
using MarvelRivalsApi.Data.Repositories.MatchHistory;
using MarvelRivalsApi.Data.Repositories.Maps;
using MarvelRivalsApi.Services.Managers;
using MarvelRivalsApi.Services.MatchHistory;
using MarvelRivalsApi.Services.MatchHistoryService;
using Microsoft.EntityFrameworkCore;
using MarvelRivalsApi.Data.Repositories.Matchhistory;

var builder = WebApplication.CreateBuilder(args);


var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200", "https://mruiweb.onrender.com" )
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(c =>
//{
//    c.CustomSchemaIds(type => type.FullName);
//    c.SwaggerDoc("v1", new() { Title = "My API", Version = "v1" });
//});
//var connectionString = "Host=postgres.railway.internal;Port=5432;Database=marvelrivalsdb;Username=postgres;Password=VKthNrcIaBaTbgJlGAcpMqJKhLsMXyDd";
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

;

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(baseConnectionString));

builder.Services.AddScoped<IHeroesService, HeroesService>();
builder.Services.AddScoped<IGameMapsService, GameMapsService>();
builder.Services.AddScoped<IMatchHistoryService, MatchHistoryService>();

builder.Services.AddScoped<IGameMapsRepository, GameMapsRepository>();
builder.Services.AddScoped<IHeroesRepository, HeroesRepository>();
builder.Services.AddScoped<IMatchHistoryRepository, MatchHistoryRepository>();


builder.Services.AddScoped<GameMapsManager>();
builder.Services.AddScoped<HeroesManager>();
builder.Services.AddScoped<MatchHistoryManager>();

string apiBaseUrl = builder.Configuration["ApiSettings:BaseUrl"] ?? "";
builder.Services.AddHttpClient<IHeroesService, HeroesService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl); // Replace with the actual base URL of the API
});
builder.Services.AddHttpClient<IGameMapsService, GameMapsService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl); // Replace with the actual base URL of the API
});
builder.Services.AddHttpClient<IMatchHistoryService, MatchHistoryService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl); // Replace with the actual base URL of the API
});


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   // app.UseSwagger();
    //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1")); // Add this line
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapGet("/", () => Results.Ok("Marvel Rivals API is running 🚀"));
app.UseCors("AllowAngularApp");
app.UseAuthorization();

app.MapControllers();

app.Run();