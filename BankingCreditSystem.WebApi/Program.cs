using BankingCreditSystem.Application;
using BankingCreditSystem.Persistence;
using BankingCreditSystem.Core.CrossCuttingConcerns.Exceptions.Middlewares;
using Microsoft.OpenApi.Models;
using BankingCreditSystem.WebApi.Exceptions;

var builder = WebApplication.CreateBuilder(args);

// CORS politikasını ekle
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Banking Credit System API", Version = "v1" });
});

// Add Application and Persistence services
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Banking Credit System API V1"));
    app.UseExceptionHandler("/error");
}
else
{
    app.UseExceptionHandler();
}

// CORS middleware'ini ekle
app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseMiddleware<GlobalExceptionHandler>();

app.UseAuthorization();
app.MapControllers();

app.Run();


