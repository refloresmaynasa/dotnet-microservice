namespace WorkerServiceBus
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using ProductService.Database;

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<DatabaseContext>();
                    services.AddSingleton<IUnitOfWork, UnitOfWork>();
                    services.AddHostedService<Worker>();
                });
    }
}
