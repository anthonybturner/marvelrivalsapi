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

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.CustomSchemaIds(type => type.FullName);
    c.SwaggerDoc("v1", new() { Title = "My API", Version = "v1" });
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    .LogTo(Console.WriteLine, LogLevel.Information)
); // Use builder.Configuration


builder.Services.AddScoped<IHeroesService, HeroesService>();
builder.Services.AddScoped<IGameMapsService, GameMapsService>();
builder.Services.AddScoped<IMatchHistoryService, MatchHistoryService>();

builder.Services.AddScoped<IGameMapsRepository, GameMapsRepository>();
builder.Services.AddScoped<IHeroesRepository, HeroesRepository>();
builder.Services.AddScoped<IMatchHistoryRepository, MatchHistoryRepository>();


builder.Services.AddScoped<GameMapsManager>();
builder.Services.AddScoped<HeroesManager>();
builder.Services.AddScoped<MatchHistoryManager>();

builder.Services.AddHttpClient<IHeroesService, HeroesService>(client =>
{
    client.BaseAddress = new Uri("https://marvelrivalsapi.com/api/"); // Replace with the actual base URL of the API
});
builder.Services.AddHttpClient<IGameMapsService, GameMapsService>(client =>
{
    client.BaseAddress = new Uri("https://marvelrivalsapi.com/api/"); // Replace with the actual base URL of the API
});
builder.Services.AddHttpClient<IMatchHistoryService, MatchHistoryService>(client =>
{
    client.BaseAddress = new Uri("https://marvelrivalsapi.com/api/"); // Replace with the actual base URL of the API
});


var app = builder.Build();
app.UseCors("AllowAngularApp");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1")); // Add this line
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();