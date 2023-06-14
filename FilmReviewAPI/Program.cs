using FilmReviewAPI.Middleware;
using FilmReviewAPI.Installers;

var builder = WebApplication.CreateBuilder(args);

// Load and install the installers
var installers = typeof(Program).Assembly.ExportedTypes
    .Where(t => typeof(IInstaller).IsAssignableFrom(t) && !t.IsInterface)
    .Select(Activator.CreateInstance)
    .Cast<IInstaller>()
    .ToList();

// Install components using each installer
foreach (var installer in installers)
{
    installer.Install(builder);
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("DevCorsPolicy");
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();

public partial class Program { }
