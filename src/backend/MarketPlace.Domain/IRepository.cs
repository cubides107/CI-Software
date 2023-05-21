using System.Linq.Expressions;

namespace MarketPlace.Domain
{
	public interface IRepository
	{
		/// <summary>
		/// guarda una entidad
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public Task Save<T>(T obj) where T : Entity;

		/// <summary>
		/// actualizar la entidad en db
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public void Update<T>(T obj) where T : Entity;

		/// <summary>
		/// retorna el usuario por id
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="id"></param>
		/// <returns></returns>
		public Task<T> Get<T>(Expression<Func<T, bool>> expression) where T : Entity;

		public Task<List<T>> GetAllNested<T>(string nested, string nested2, string nested3) where T : Entity;

		/// <summary>
		/// verificar si existe
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="expression"></param>
		/// <returns></returns>
		public bool Exists<T>(Expression<Func<T, bool>> expression) where T : Entity;

		/// <summary>
		/// Guarda los datos en la db
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public Task Commit();

		/// <summary>
		/// Obtener una lista de entidades con un condicion
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="expressionConditional"></param>
		/// <returns></returns>
		public Task<List<T>> GetAll<T>() where T : Entity;

		/// <summary>
		/// Obtener lista de entidades con anidados
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="expressionConditional"></param>
		/// <param name="nested"></param>
		/// <returns></returns>
		public Task<List<T>> GetAllNested<T>(Expression<Func<T, bool>> expressionConditional, string nested, string nested2) where T : Entity;

	}
}
