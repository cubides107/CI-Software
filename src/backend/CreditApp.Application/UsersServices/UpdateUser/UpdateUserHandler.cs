using CreditApp.Domain;
using CreditApp.Domain.UserEntities;
using MediatR;

namespace CreditApp.Application.UsersServices.UpdateUser
{
	public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, int>
	{
		private readonly IRepository repository;

		private readonly ISecurity security;

		public UpdateUserHandler(IRepository repository, ISecurity security)
		{
			this.repository = repository;
			this.security = security;
		}

		public async Task<int> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
		{
			User user;

			int id = int.Parse(security.GetClaim(request.Claims, ISecurity.USERID));

			user = await repository.Get<User>(x => x.Id == id);

			user.Update(
				names: request.Names,
				lastNames: request.LastNames,
				email: request.Email
			);

			repository.Update<User>(user);
			await repository.Commit();

			return 0;
		}
	}
}
