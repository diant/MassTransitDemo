using MassTransit;
using MassTransitDemo.Middleware;

namespace MassTransitDemo
{
    internal static class AppExtensions
    {
        internal static WebApplicationBuilder AddMassTransitWithMediator(this WebApplicationBuilder builder)
        {
            builder.Services.AddMediator(c =>
            {
                c.ConfigureMediator((context, mc) =>
                {
                    mc.UseSendFilter(typeof(LogFilter<>), context);
                });
                c.AddConsumers(typeof(Program).Assembly);
            });

            return builder;
        }
    }
}