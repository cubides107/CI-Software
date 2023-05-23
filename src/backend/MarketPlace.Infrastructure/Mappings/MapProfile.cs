using AutoMapper;
using CreditApp.Application.ProductServices.GetProduct;
using CreditApp.Application.UsersServices.GetUser;
using MarketPlace.Domain.ProductEntities;
using MarketPlace.Domain.UserEntities;

namespace MarketPlace.Infrastructure.Mappings
{
	public class MapProfile :Profile
	{
        public MapProfile()
        {
            this.CreateMap<User, GetUserDTO>();
            this.CreateMap<Product, GetProductDTO>();
        }
    }
}
