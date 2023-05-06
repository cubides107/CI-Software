using System.Linq.Expressions;
using MarketPlace.Domain;
using MarketPlace.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infrastructure.Repositories
{
	public class CreditAppRepositorySQL : IRepository
	{
		protected readonly CreditAppContext context;


		public CreditAppRepositorySQL(CreditAppContext context)
		{
			this.context = context;
		}

		public async Task Commit()
		{
			try
			{
				await context.SaveChangesAsync();
			}
			catch (Exception e)
			{
				throw new Exception($"{e.Message}");
			}
		}


		public bool Exists<T>(Expression<Func<T, bool>> expression) where T : Entity
		{
			try
			{
				return context.Set<T>()
					.Any(expression);
			}
			catch (Exception e)
			{
				throw new Exception($"{e.Message}");
			}
		}

		public async Task<T> Get<T>(Expression<Func<T, bool>> expression) where T : Entity
		{
			try
			{
				return await context.Set<T>().FirstOrDefaultAsync(expression);
			}
			catch (Exception e)
			{
				throw new Exception($"{e.Message}");
			}
		}

		public async Task Save<T>(T obj) where T : Entity
		{
			try
			{
				await context.Set<T>().AddAsync(obj);
			}
			catch (Exception e)
			{
				throw new Exception($"{e.Message}");
			}
		}

		public void Update<T>(T obj) where T : Entity
		{
			try
			{
				context.Update<T>(obj);
			}
			catch (Exception e)
			{
				throw new Exception($"{e.Message}");
			}
		}

		public async Task<List<T>> GetAll<T>(Expression<Func<T, bool>> expressionConditional) where T : Entity
		{
			try
			{
				return await context.Set<T>()
					.Where(expressionConditional)
					.ToListAsync();
			}
			catch (Exception e)
			{
				throw new Exception($"{e.Message}");
			}
		}

		public async Task<List<T>> GetAllNested<T>(string nested, string nested2, string nested3) where T : Entity
		{
			try
			{
				return await context.Set<T>()
					.Include(nested)
				    .Include(nested2)
				    .Include(nested3)
					.ToListAsync();
			}
			catch (Exception e)
			{
				throw new Exception($"{e.Message}");
			}
		}

		public async Task<List<T>> GetAllNested<T>(Expression<Func<T, bool>> expressionConditional, string nested) where T : Entity
		{
			try
			{
				return await context.Set<T>()
				   .Where(expressionConditional)
				   .Include(nested)
				   .ToListAsync();
			}
			catch (Exception e)
			{
				throw new Exception($"{e.Message}");
			}

		}
		public async Task<List<T>> GetAllNested<T>(Expression<Func<T, bool>> expressionConditional, string nested, string nested2) where T : Entity
		{
			try
			{
				return await context.Set<T>()
				   .Where(expressionConditional)
				   .Include(nested)
				   .Include(nested2)
				   .ToListAsync();
			}
			catch (Exception e)
			{
				throw new Exception($"{e.Message}");
			}

		}
	}
}
