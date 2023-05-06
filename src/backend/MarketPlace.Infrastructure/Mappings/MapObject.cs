using AutoMapper;
using MarketPlace.Domain;

namespace MarketPlace.Infrastructure.Mappings
{
	public class MapObject : IMapObject
	{
		private readonly IMapper mapper;

		public MapObject(IMapper mapper)
		{
			this.mapper = mapper;
		}

		public TDestination Map<TSourse, TDestination>(TSourse sourse)
		{
			try
			{
				return mapper.Map<TSourse, TDestination>(sourse);
			}
			catch (Exception e)
			{

				throw new Exception($"Error de mapeo: {e.Message}");
			}
		}
	}
}

