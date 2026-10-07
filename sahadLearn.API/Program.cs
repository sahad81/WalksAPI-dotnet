using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using sahadLearn.API.Data;
using sahadLearn.API.mapping;
using sahadLearn.API.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<sahadLearnDbContext>(dbContextOptions => dbContextOptions.UseSqlServer(builder.Configuration.GetConnectionString("SahadLearnConnectionString")));
builder.Services.AddScoped<IRegionRepository, SQLRegionRepository>();
builder.Services.AddScoped<IwalkRepository, SQLWalkRepository>();
builder.Services.AddAutoMapper(cfg => { }, typeof(automapperProfiles)); 
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
