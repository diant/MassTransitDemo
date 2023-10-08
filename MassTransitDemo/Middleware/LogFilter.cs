using MassTransit;

using Microsoft.Extensions.Options;

 

namespace MassTransitDemo.Middleware;

 

internal sealed class LogFilter<T> : IFilter<SendContext<T>>

    where T : class

{

    private readonly ILogger<LogFilter<T>> _logger;

    private readonly IOptions<LogOptions> _options;

 

    public LogFilter(ILogger<LogFilter<T>> logger, IOptions<LogOptions> options)

    {

        _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        _options = options ?? throw new ArgumentNullException(nameof(options));

    }

 

    public void Probe(ProbeContext context) { }

 

    public Task Send(SendContext<T> context, IPipe<SendContext<T>> next)

    {

        switch (_options.Value.Default)

        {

            case "Information":

                _logger.LogInformation("{Request}/{Message}", context.Message.GetType().FullName, "Inside the filter");

                break;

            case "Trace":

                _logger.LogTrace("{Request}/{Message}", context.Message.GetType().FullName, "Inside the filter");

                break;

            default:

                _logger.LogInformation("{Request}/{Message}", context.Message.GetType().FullName, "Inside the filter");

                break;

        }

 

        return next.Send(context);

    }

}