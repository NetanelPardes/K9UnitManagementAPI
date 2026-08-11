using K9UnitManagementAPI.Data;
using K9UnitManagementAPI.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<K9UnitManagementDbContext>(options =>
{
    var ConnectionStrings = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseMySql(ConnectionStrings, ServerVersion.AutoDetect(ConnectionStrings));
});

builder.Services.AddScoped<IDogRepository, DogRepository>();

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
