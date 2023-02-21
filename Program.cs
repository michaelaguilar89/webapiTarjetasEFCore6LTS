using Microsoft.EntityFrameworkCore;
using WebApiTarjetas.Conexion;
using WebApiTarjetas.Repository_s;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<CardInterface,CardRepository>();

//Using dependency injection I add the connection string that is in my app.settings.json

builder.Services.AddDbContext<AppDBContext>(opt =>
{
	opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConection"));
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
