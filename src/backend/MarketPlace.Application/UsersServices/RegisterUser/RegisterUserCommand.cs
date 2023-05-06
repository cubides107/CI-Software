using MediatR;

namespace CreditApp.Application.UsersServices.RegisterUser
{
	public class RegisterUserCommand:IRequest<int>
	{
		public string Names { get; set; }

		public string LastNames { get; set; }

		public string Email { get; set; }

		public string Password { get; set; }
	}
}
