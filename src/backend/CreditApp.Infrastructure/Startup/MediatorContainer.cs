using CreditApp.Application.UsersServices.LoginUser;
using CreditApp.Application.UsersServices.RegisterUser;
using Microsoft.Extensions.DependencyInjection;

namespace CreditApp.Infrastructure.Startup
{
	public class MediatorContainer
	{
		public static void Configure(IServiceCollection services)
		{
			services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(RegisterUserCommand).Assembly));
			services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(LoginUserCommand).Assembly));
		}
	}
}
