using MassTransitDemo;
using MassTransitDemo.WeatherForecast; 

var builder = WebApplication.CreateBuilder(args)
    .AddMassTransitWithMediator()
    .BindConfig(); 

var app = builder.Build();

app.UseHttpsRedirection();
app.MapWeatherForecastEndpoints();
app.Run();
