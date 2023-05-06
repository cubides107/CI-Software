using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain
{
	public interface IMapObject
	{
		public TDestination Map<TSource, TDestination>(TSource source);
	}
}
