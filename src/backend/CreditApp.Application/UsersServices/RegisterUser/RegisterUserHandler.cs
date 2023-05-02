using CreditApp.Domain;
using CreditApp.Domain.UserEntities;
using MediatR;

namespace CreditApp.Application.UsersServices.RegisterUser
{
	public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, int>
	{

		private readonly IRepository repository;

		private readonly ISecurity security;

		public RegisterUserHandler(IRepository repository, ISecurity security)
		{
			this.repository = repository;
			this.security = security;
		}

		public async Task<int> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
		{
			if (repository.Exists<User>(x => x.Email == request.Email))
				throw new Exception("El usuario ya se encuentra registrado");

			string EncryptPassword = security.EncryptPassword(request.Password);

			User user = new User(
				names: request.Names,
				lastNames: request.LastNames,
				email: request.Email,
				password: EncryptPassword);

			await repository.Save(user);
			await repository.Commit();

			return 0;
		}
	}
}
