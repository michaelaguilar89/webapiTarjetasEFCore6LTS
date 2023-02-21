using WebApiTarjetas.Models;

namespace WebApiTarjetas.Response
{
	public class response
	{
		public string DisplayMessages { get; set; }

		public bool IsSucces { get; set; } = true;

		public Object Result { get; set; }

		public List<String> errorMessages { get; set; }
	}
}
