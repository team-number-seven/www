namespace www.Backend.IdentityServer.Configures;

internal static class LogConfiguration
{
    internal static string SerilogFormat =>
        "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}";
}