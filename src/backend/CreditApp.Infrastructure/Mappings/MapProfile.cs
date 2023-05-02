using AutoMapper;
using CreditApp.Application.UsersServices.GetUser;
using CreditApp.Domain.UserEntities;

namespace CreditApp.Infrastructure.Mappings
{
	public class MapProfile :Profile
	{
        public MapProfile()
        {
            this.CreateMap<User, GetUserDTO>();
        }
    }
}
