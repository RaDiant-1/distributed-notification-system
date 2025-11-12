using Microsoft.EntityFrameworkCore;
using NotificationGateway.Configuration;
using NotificationGateway.Data;
using NotificationGateway.IService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuration
builder.Services.Configure<RabbitMQConfig>(
    builder.Configuration.GetSection("RabbitMQ"));

// Database Context
string connectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<NotificationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Services
builder.Services.AddScoped<IMessagePublisherService, RabbitMQPublisherService>();
builder.Services.AddScoped<INotificationService, NotificationService>();

// HttpClient for external service calls (User Service, Template Service)
builder.Services.AddHttpClient("UserService", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["Services:UserService"]!);
});

builder.Services.AddHttpClient("TemplateService", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["Services:TemplateService"]!);
});

// Health Checks
builder.Services.AddHealthChecks()
    .AddDbContextCheck<NotificationDbContext>()
    .AddRabbitMQ(
        rabbitConnectionString:
            $"amqp://{builder.Configuration["RabbitMQ:Username"]}:{builder.Configuration["RabbitMQ:Password"]}@{builder.Configuration["RabbitMQ:Host"]}:{builder.Configuration["RabbitMQ:Port"]}");



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();


// Health check endpoint
app.MapHealthChecks("/health");


app.Run();


