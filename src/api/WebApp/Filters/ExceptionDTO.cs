namespace WebApp.Filters
{
	public class ExceptionDTO
	{
		public string Message { get; set; }
		public string Type { get; set; }
		public object Aplication { get; set; }

		public int StatusCode { get; set; }
	}
}
