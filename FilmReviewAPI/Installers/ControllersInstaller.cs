namespace FilmReviewAPI.Installers
{
    public class ControllersInstaller : IInstaller
    {
        public void Install(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
        }
    }
}
