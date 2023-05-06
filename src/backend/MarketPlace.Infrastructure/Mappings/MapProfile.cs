using AutoMapper;
using CreditApp.Application.UsersServices.GetUser;
using MarketPlace.Domain.UserEntities;

namespace MarketPlace.Infrastructure.Mappings
{
	public class MapProfile :Profile
	{
        public MapProfile()
        {
            this.CreateMap<User, GetUserDTO>();
        }
    }
}
