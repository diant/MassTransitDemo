using MassTransitDemo;
using MassTransitDemo.WeatherForecast;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args)
    .AddMassTransitWithMediator()
    .BindConfig();

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
app.MapWeatherForecastEndpoints();
app.Run();
