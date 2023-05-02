namespace WebApp.Controllers.Users
{
	public class RequestUpdateUser
	{
		public string Names { get; set; }

		public string Email { get; set; }

		public string DocumentId { get; set; }

		public string PhoneNumber { get; set; }

		public DateTime DateOfBirth { get; set; }

		public string LandLine { get; set; }

		public string Address { get; set; }

		public string LastNames { get; set; }

		public string Congregation { get; set; }

		public string District { get; set; }

		public string EPS { get; set; }

		public double Weight { get; set; }

		public double Height { get; set; }

		public DateTime DateInitCorp { get; set; }

		public DateTime DateInitMin { get; set; }


		//Informacion de la esposa
		public string WifeNames { get; set; }

		public string WifeLastNames { get; set; }

		public string WifePhone { get; set; }

		public int Childrens { get; set; }

		public int Persons { get; set; }
	}
}