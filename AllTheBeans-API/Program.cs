using AllTheBeans_API.Data;
using AllTheBeans_API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (builder.Environment.IsDevelopment())
{
    var root = builder.Environment.ContentRootPath;
    var dbPath = Path.Combine(root, "Data/allTheBeans.db");
    connectionString = $"Data Source={dbPath};";
}

// Add services to the container.

builder.Services.AddDbContext<CoffeeDbContext>(options => 
    options.UseSqlite(connectionString));

builder.Services.AddControllers();

builder.Services.AddScoped<BeanOfTheDayService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        Console.WriteLine("Seeding database...");
        var json = await File.ReadAllTextAsync("Data/coffees.json");
        await SeedData.Initialize(services, json);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred seeding the DB.");
        Console.WriteLine("An error occurred seeding the DB.");
    }
    finally
    {
        Console.WriteLine("Seeding database done");
    }
}

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