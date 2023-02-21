using System.ComponentModel.DataAnnotations;

namespace WebApiTarjetas.Models
{
	public class card
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string userName { get; set; }
		[Required]
		public string cardNUmber { get; set; }
		[Required]
		public string ExpirationDate { get; set; }
	}
}
