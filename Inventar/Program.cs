using Inventar.Models;
using Inventar.Persistance;
using Inventar.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<InventarDatabaseSettings>(
   builder.Configuration.GetSection(nameof(InventarDatabaseSettings)));

builder.Services.AddSingleton<IInventarDatabaseSettings>(x =>
    x.GetRequiredService<IOptions<InventarDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(x =>
    new MongoClient(builder.Configuration.GetValue<string>("InventarDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<IProstorijaService, ProstorijaService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer("Server=.; Database=Inventar; Trusted_Connection=yes;"));

var app = builder.Build();

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
