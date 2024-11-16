using LBAreas.Entities.Data;
using LBAreas.Services.Mappings;
using LBAreas.Services.Repositories;
using LBAreas.Services.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add Database
builder.Services.AddDbContext<LBAreasDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LBAreasConnectionString"));
});


// Inject Repositories
builder.Services.AddScoped<IRegionRepository, SQLRegionRepository>();



// Add AutoMapper
builder.Services.AddAutoMapper(typeof(MapperProfiles));


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
