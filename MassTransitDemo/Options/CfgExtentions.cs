internal static class CfgExtentions
{
    internal static WebApplicationBuilder BindConfig(this WebApplicationBuilder builder)
    {
        builder.Configuration.GetSection(LogOptions.ConfigurationSectionName).Bind(new LogOptions());
        return builder;
    }
}