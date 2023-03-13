using Serilog;

namespace www.Backend.IdentityServer;

internal static class HostingExtensions
{
    public static IHostBuilder UseLogger(this IHostBuilder builder, string templateFormat)
    {
        builder.UseSerilog((ctx, lc) => lc
            .WriteTo.Console(outputTemplate: templateFormat)
            .Enrich.FromLogContext()
            .ReadFrom.Configuration(ctx.Configuration));

        return builder;
    }

    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        var services = builder.Services;
        services.AddControllersWithViews();
        services.AddCors(configure =>
            configure.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseSerilogRequestLogging();
        app.UseHttpsRedirection();
        if (app.Environment.IsDevelopment()) app.UseDeveloperExceptionPage();

        app.UseCors();
        app.UseRouting();

        app.UseEndpoints(configure => configure.MapDefaultControllerRoute());

        return app;
    }
}