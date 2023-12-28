using MagicVilla_API.Controllers;
using MagicVilla_API.Logging;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//// Logging in Program.cs using Serilog
//Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
//    .WriteTo.File("log/villaLog.txt", rollingInterval:RollingInterval.Day).CreateLogger();

//builder.Host.UseSerilog();

builder.Services.AddControllers(option =>
{
    option.ReturnHttpNotAcceptable = true; // returning 406 statusCode
}).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters(); // xml format following
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// for custom logging
builder.Services.AddSingleton<ILogging, Logging>();

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
