using MassTransit.Mediator;

namespace MassTransitDemo.WeatherForecast;

public sealed class WeatherforecastHandler : MediatorRequestHandler<WeatherForecastRequest, WeatherForecastResponse>
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherforecastHandler> _logger; 

    public WeatherforecastHandler(ILogger<WeatherforecastHandler> logger) =>_logger = logger;

    protected override Task<WeatherForecastResponse> Handle(WeatherForecastRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("{Request}/{Message}", request.GetType().FullName, GetType().FullName);

        var response = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
       .ToArray();

        return Task.FromResult(new WeatherForecastResponse(response));
    }
}
 
public record WeatherForecastRequest() : Request<WeatherForecastResponse>;
public record WeatherForecastResponse(ICollection<WeatherForecast> WeatherForecasts);