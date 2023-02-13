using Microsoft.EntityFrameworkCore;
using NotificationApiService.Models;
using NotificationApiService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContext>(option =>
{
    var connectionString = builder.Configuration.GetConnectionString("Default");
    option.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddScoped<INotificationService, NotificationService>();

var app = builder.Build();
string queueName = "CricApp";
string connectionString = builder.Configuration["ConnectionStrings:Default"];
await RabbitMQService.StartConsumer(queueName, connectionString);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

