using LBAreas.Entities.Data;
using LBAreas.Services.Mappings;
using LBAreas.Services.Repositories;
using LBAreas.Services.Repositories.IRepositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

builder.Services.AddDbContext<LBAreasAuthDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LBAreasAuthConnectionString"));
});

// Inject Repositories
builder.Services.AddScoped<IRegionRepository, SQLRegionRepository>();
builder.Services.AddScoped<IWalkRepository, SQLWalkRepository>();


// Add AutoMapper
builder.Services.AddAutoMapper(typeof(MapperProfiles));


// Add Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Add Authentication here
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
