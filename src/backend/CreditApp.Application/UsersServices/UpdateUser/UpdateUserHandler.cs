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
				documentId: request.DocumentId,
				dateOfBirth: request.DateOfBirth,
				email: request.Email,
				landLine: request.LandLine,
				address: request.Address,
				congregation: request.Congregation,
				district: request.District,
				EPS: request.EPS,
				phoneNumber: request.PhoneNumber,
				weight: request.Weight,
				height: request.Height,
				dateInitCor: request.DateInitCorp,
				dateInitMin: request.DateInitMin,
				wifeNames: request.WifeNames,
				wifeLastNames: request.LastNames,
				wifePhone: request.WifePhone,
				childrens: request.Childrens,
				persons: request.Persons
				);

			repository.Update<User>(user);
			await repository.Commit();

			return 0;
		}
	}
}
