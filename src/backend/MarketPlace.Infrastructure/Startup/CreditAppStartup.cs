using Azure.Storage.Blobs;
using MarketPlace.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MarketPlace.Infrastructure.Startup
{
    public class CreditAppStartup
    {
        public static void SetUp(IServiceCollection services, IConfiguration configuration)
        {
            ConfigureContext(services, configuration);
            ConfigureIOC(services);
            ConfigureMediador(services);
            ConfigureMapper(services);
            ConfigureBlobStorage(services,configuration);
        }

        private static void ConfigureContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CreditAppContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("MarketPlaceConnection")));
        }

        private static void ConfigureBlobStorage(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(x => new BlobServiceClient(configuration.GetConnectionString("AzureBlobStorageConnection")));
        }

        private static void ConfigureIOC(IServiceCollection services)
        {
            InjectionContainer.Inyection(services);
        }

        private static void ConfigureMediador(IServiceCollection services)
        {
            MediatorContainer.Configure(services);
        }

        private static void ConfigureMapper(IServiceCollection services)
        {
            //mapeo de entidades
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}