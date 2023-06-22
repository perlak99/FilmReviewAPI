namespace FilmReviewAPI.Installers
{
    public class CacheInstaller : IInstaller
    {
        public void Install(WebApplicationBuilder builder)
        {
            builder.Services.AddMemoryCache();
        }
    }
}
