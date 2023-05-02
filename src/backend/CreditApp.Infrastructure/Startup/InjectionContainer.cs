using Azure.Storage.Blobs;
using CreditApp.Domain;
using CreditApp.Infrastructure.Mappings;
using CreditApp.Infrastructure.Repositories;
using CreditApp.Infrastructure.Securities;
using Microsoft.Extensions.DependencyInjection;

namespace CreditApp.Infrastructure.Startup
{
	public class InjectionContainer
	{
		public static void Inyection(IServiceCollection services)
		{
			services.AddScoped<IRepository, CreditAppRepositorySQL>();
			services.AddScoped<ISecurity, Security>();
			services.AddScoped<IMapObject, MapObject>();
			services.AddScoped<IAzureStorage, BlobRepository>();
		}
	}
}
