using api.Data;
using api.Interfaces;
using api.Repository;
using api.Respository;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop.Infrastructure;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

DotNetEnv.Env.Load();

string? password = Environment.GetEnvironmentVariable("AZURE_PASSWORD") ?? "password is empty";
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")?.Replace("{Password}", password) ?? "Connection string is empty";


builder.Services.AddDbContext<ApplicationDBContext>(options => 
{
    options.UseSqlServer(connectionString,
    sqlOptions => sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5, // Number of retry attempts
                maxRetryDelay: TimeSpan.FromSeconds(10), // Delay between retries
                errorNumbersToAdd: null) // Optional specific error numbers to retry on  
    );
});

builder.Services.AddScoped<IBusinessRepository, BusinessRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();

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
