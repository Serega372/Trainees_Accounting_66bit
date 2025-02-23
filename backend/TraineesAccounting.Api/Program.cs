using Microsoft.EntityFrameworkCore;
using TraineesAccounting.Api.Services;
using TraineesAccounting.Persistence;
using TraineesAccounting.Persistence.Abstract;
using TraineesAccounting.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseContext>(
    options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(DatabaseContext)));
    });

builder.Services.AddScoped<ITraineesRepository, TraineesRepository>();
builder.Services.AddScoped<IProjectsRepository, ProjectsRepository>();
builder.Services.AddScoped<IInternshipDirectionsRepository, InternshipDirectionsRepository>();
builder.Services.AddScoped<ITraineesService, TraineesService>();
builder.Services.AddAutoMapper(typeof(AppMappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();