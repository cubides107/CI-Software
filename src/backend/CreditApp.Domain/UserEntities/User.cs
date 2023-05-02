using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreditApp.Domain.UserEntities
{
	public class User : Entity
	{
		[MaxLength(30)]
		public string Names { get; set; }

		public TypeUser TypeUser { get; set; }

		[MaxLength(50)]
		public string Email { get; set; }

		[MaxLength(20)]
		public string? DocumentId { get; set; }

		public DateTime? DateOfBirth { get; set; }

		public string? LandLine { get; set; }

		public string? Address { get; set; }

		[ForeignKey("Department")]
		public int? DepartmentId { get; set; }

		[ForeignKey("Municipality")]
		public int? MunicipalityId { get; set; }

		public string? PhoneNumber { get; set; }

		[MaxLength(30)]
		public string LastNames { get; set; }

		[MaxLength(30)]
		public string? Congregation { get; set; }

		[MaxLength(30)]
		public string? District { get; set; }

		[MaxLength(40)]
		public string? EPS { get; set; }

		public double? Weight { get; set; }

		public double? Height { get; set; }

		public DateTime? DateInitCorp { get; set; }

		public DateTime? DateInitMin { get; set; }

		[MaxLength(100)]
		public string? Password { get; set; }

		[MaxLength(600)]
		public string? Token { get; set; }


		//Informacion de la Esposa

		public string? WifeNames { get; set; }

		public string? WifeLastNames { get; set; }

		public string? WifePhone { get; set; }

		public int? Childrens { get; set; }

		public int? Persons { get; set; }



		/// <summary>
		/// For EF
		/// </summary>
		private User() : base()
		{

		}

		public User(string names, string lastNames, string email, string password)
		{
			Names = names;
			LastNames = lastNames;
			Email = email;
			Password = password;
		}

		public void Update(string names, string lastNames, string documentId,string phoneNumber, DateTime dateOfBirth, string email,
			string landLine, string address, string congregation, string district, string EPS, double weight, double height,
			DateTime dateInitCor, DateTime dateInitMin, string wifeNames, string wifeLastNames, string wifePhone, int childrens,
			int persons)
		{
			Names = names;
			LastNames = lastNames;
			DocumentId = documentId;
			DateOfBirth = dateOfBirth;
			Email = email;
			LandLine = landLine;
			Address = address;
			Congregation = congregation;
			PhoneNumber = phoneNumber;
			District = district;
			this.EPS = EPS;
			Weight = weight;
			Height = height;
			DateInitCorp = dateInitCor;
			DateInitMin = dateInitMin;
			WifeNames = wifeNames;
			WifeLastNames = wifeLastNames;
			WifePhone = wifePhone;
			Childrens = childrens;
			Persons = persons;
		}
	}
}
