using CreditApp.Domain;
using CreditApp.Domain.UserEntities;
using MediatR;

namespace CreditApp.Application.UsersServices.GetUser
{
	public class GetUserHandler : IRequestHandler<GetUserQuery, GetUserDTO>
	{
		private readonly IRepository repository;

		private readonly ISecurity security;

		private readonly IMapObject mapObject;

		public GetUserHandler(IRepository repository, ISecurity security, IMapObject mapObject)
		{
			this.repository = repository;
			this.security = security;
			this.mapObject = mapObject;
		}

		public async Task<GetUserDTO> Handle(GetUserQuery request, CancellationToken cancellationToken)
		{
			User user;

			int id = int.Parse(security.GetClaim(request.Claims, ISecurity.USERID));

			user = await repository.Get<User>(x => x.Id == id);

			return mapObject.Map<User,GetUserDTO>(user);
		}
	}
}
