using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RareBirdsApi.Configs;
using RareBirdsApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Converts enum to string value
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.
           Add(new JsonStringEnumConverter());

    options.JsonSerializerOptions.DefaultIgnoreCondition =
             JsonIgnoreCondition.WhenWritingNull;
});

builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.AddIdentityCore<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<RareBirdsDbContext>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("RareBirdsDbConnectionString");
builder.Services.AddDbContext<RareBirdsDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});



//Allow or restrics sharing of resources across domains
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
     b => b.AllowAnyHeader()
    .AllowAnyOrigin()
    .AllowAnyMethod());
});


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
