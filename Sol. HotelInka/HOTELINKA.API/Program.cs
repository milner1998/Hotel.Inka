using FluentValidation.AspNetCore;
using HOTELINKA.API.Configuration;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
 
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(HttpGlobalExceptionFilter));
});

// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("NewPolitic", app =>
    {
        app.AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod();
    });
});

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddEndpointsApiExplorer();

#region SwaggerConf
builder.Services.SetSwaggerConfig(builder.Configuration);
#endregion
 
#region Context SQLSERVER
builder.Services.SetDBConnection(builder.Configuration);
#endregion

#region Dependency Injection
builder.Services.SetInjection(builder.Configuration);
#endregion

#region Automapper
builder.Services.SetAutoMapper(builder.Configuration);
#endregion
  
#region Logger
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.File("log/HOTELINKALog.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
#endregion

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Aplicar CORS antes de la autenticación y autorización
app.UseCors("NewPolitic");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
