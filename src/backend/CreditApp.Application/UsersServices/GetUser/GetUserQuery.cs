using MediatR;
using System.Security.Claims;

namespace CreditApp.Application.UsersServices.GetUser
{
	public class GetUserQuery : IRequest<GetUserDTO>
	{
		public List<Claim> Claims { get; set; }
	}
}
