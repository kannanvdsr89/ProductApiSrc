using Microsoft.Extensions.Configuration;
using ProductAPI;
using Serilog;
using Serilog.Formatting.Compact;
using System;

var builder = WebApplication.CreateBuilder(args);
var startup = new Startup(builder.Configuration);// call start up class
var logger = new LoggerConfiguration()
        .ReadFrom.Configuration(startup.Configuration)
        .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

startup.ConfigureServices(builder.Services);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//startup.CreateHostBuilder(args);
var app = builder.Build();

startup.Configure(app, builder.Environment);


