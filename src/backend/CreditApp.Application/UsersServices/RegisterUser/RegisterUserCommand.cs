using MediatR;

namespace CreditApp.Application.UsersServices.RegisterUser
{
	public class RegisterUserCommand:IRequest<int>
	{
		public string Names { get; set; }

		public string LastNames { get; set; }

		public string DocumentId { get; set; }

		public DateTime DateOfBirth { get; set; }

		public string Email { get; set; }

		public string Password { get; set; }

	/*	public string Country { get; set; }

		public string EPS { get; set; }

		public double Height { get; set; }

		public double Weight { get; set; }	

		public DateTime DateInitCorp { get; set; }

		public DateTime DateInitMinistry { get; set; }

		public string District { get; set; }*/
	}
}
