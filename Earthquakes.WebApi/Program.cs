using Earthquakes.DataAccess;
using Earthquakes.Logic.Mapper;
using Earthquakes.Logic.Service;
using Earthquakes.LogicInterface.ServiceInterface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Database
builder.Services.AddDbContext<EarthquakeContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("Earthquake"),
        x =>
        {
            x.MigrationsAssembly(typeof(Program).Assembly.FullName);
            x.MigrationsHistoryTable("MigrationHistory");
        }
    );
});

// Automapper
builder.Services.AddSingleton(MappingProfiles.GetMappings().CreateMapper());

// Services
builder.Services.AddTransient<IDummyDataReader, DummyDataReader>();
builder.Services.AddTransient<ITypeService, TypeService>();
builder.Services.AddTransient<IEarthquakeService, EarthquakeService>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
