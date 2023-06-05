using Serilog;

namespace FilmReviewAPI.Installers
{
    public class LoggerInstaller : IInstaller
    {
        public void Install(WebApplicationBuilder builder)
        {
            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .Enrich.FromLogContext()
                .CreateLogger();

            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(logger);
        }
    }
}
