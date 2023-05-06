using MarketPlace.Domain;
using MarketPlace.Infrastructure.Mappings;
using MarketPlace.Infrastructure.Repositories;
using MarketPlace.Infrastructure.Securities;
using Microsoft.Extensions.DependencyInjection;

namespace MarketPlace.Infrastructure.Startup
{
	public class InjectionContainer
	{
		public static void Inyection(IServiceCollection services)
		{
			services.AddScoped<IRepository, CreditAppRepositorySQL>();
			services.AddScoped<ISecurity, Security>();
			services.AddScoped<IMapObject, MapObject>();
		}
	}
}
