using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MarketPlace.Domain.ProductEntities;

namespace MarketPlace.Domain.UserEntities
{
	public class User : Entity
	{
		[MaxLength(30)]
		public string Names { get; set; }

		public TypeUser TypeUser { get; set; }

		[MaxLength(50)]
		public string Email { get; set; }

		[MaxLength(30)]
		public string LastNames { get; set; }
		
		[MaxLength(100)]
		public string? Password { get; set; }

		[MaxLength(600)]
		public string? Token { get; set; }

		public List<Product> Products { get; set; }

		/// <summary>
		/// For EF
		/// </summary>
		private User() : base()
		{
			Products = new List<Product>();
		}

		public User(string names, string lastNames, string email, string password)
		{
			Names = names;
			LastNames = lastNames;
			Email = email;
			Password = password;
		}

		public void AddProduct(Product product)
		{
			Products.Add(product);
		}

		public void Update(string names, string lastNames, string email)
		{
			Names = names;
			LastNames = lastNames;
			Email = email;
		}
	}
}
