using MarvelRivalsApiAPI.Services.GameMapService;
using MarvelRivalsApiAPI.Services.MarvelRivalsApiAPI.Services;
using MarvelRivalsApiAPI.Services.MatchDetailService;
using Microsoft.EntityFrameworkCore; // Ensure this using directive is present  

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IGameMapService, GameMapService>();
builder.Services.AddScoped<IMatchHistoryService, MatchHistoryService>();
builder.Services.AddScoped<IMatchDetailService, MatchDetailService>();

builder.Services.AddDbContext<MarvelRivalsApiAPI.Data.MarvelRivalsDBContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors(); // Add this before app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();