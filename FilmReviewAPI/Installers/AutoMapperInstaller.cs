namespace FilmReviewAPI.Installers
{
    public class AutoMapperInstaller : IInstaller
    {
        public void Install(WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(Program).Assembly);
        }
    }
}
