namespace FilmReviewAPI.Installers
{
    public class CorsInstaller : IInstaller
    {
        public void Install(WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("DevCorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                });
            });
        }
    }
}
