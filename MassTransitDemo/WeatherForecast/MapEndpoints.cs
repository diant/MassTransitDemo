using MassTransit;
using MassTransit.Mediator;

namespace MassTransitDemo.WeatherForecast;

 internal static class MapEndpoints
{
    private const string baseRoute = "/api";
    internal static IApplicationBuilder MapWeatherForecastEndpoints(this WebApplication app)
    {
        const string controllerRoute = "weatherforecast";       

        app.MapGet($"{baseRoute}/{controllerRoute}", async (IMediator mediator) =>
            await mediator.SendRequest(new WeatherForecastRequest()));

       return app;
    }
}