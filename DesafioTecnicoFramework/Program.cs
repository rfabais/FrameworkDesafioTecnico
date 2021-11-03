using DesafioTecnicoFramework.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioTecnicoFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();

            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            serviceProvider.GetService<ICalculadora>().Start();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IConsoleHelper, ConsoleHelper>();
            services.AddScoped<ICalculadora, Calculadora>();
        }
    }
}
