using MassTransit;
using MassTransit.Mediator;

namespace MassTransitDemo.WeatherForecast;

 internal static class MapEndpoints
{
    internal static IApplicationBuilder MapWeatherForecastEndpoints(this WebApplication app)
    {
        const string baseRoute = "/api";
        const string controllerRoute = "weatherforecast";       

        app.MapGet($"{baseRoute}/{controllerRoute}", async (IMediator mediator) =>
            await mediator.SendRequest(new WeatherForecastRequest()));

       return app;
    }
}