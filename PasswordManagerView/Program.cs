using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PasswordManager.Application.Extensions;
using PasswordManager.Persistence.Extensions;
using PasswordManager.Domain.Extensions;
namespace PasswordManagerView
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddSingleton<App>();
                    services.AddSingleton<MainWindow>();
                    services.AddSingleton<WindowCreatingPassword>();
                    services.AddDomainLayer();
                    services.AddApplicationLayer();
                    services.AddPersistenceLayer();
                }).Build();


            App? app = host.Services.GetService<App>();
            app?.Run();
        }
    }
}
