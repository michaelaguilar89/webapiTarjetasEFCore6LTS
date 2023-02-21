using WebApiTarjetas.Models;

namespace WebApiTarjetas.Repository_s
{
	public interface CardInterface
	{
		Task<List<card>> GetCards();

		Task<card> GetCardById(int id);

		Task<string> createUpdateCard(card myCard);

		Task<string> removeCard(int id);
	}
}
