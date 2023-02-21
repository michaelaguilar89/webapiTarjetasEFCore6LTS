using Microsoft.EntityFrameworkCore;
using WebApiTarjetas.Conexion;
using WebApiTarjetas.Models;

namespace WebApiTarjetas.Repository_s
{
	public class CardRepository : CardInterface
	{

		private readonly AppDBContext _db;
		private string menssages;
		public CardRepository(AppDBContext db)
		{
			_db = db;
		}

		public async Task<string> createUpdateCard(card myCard)
		{
	
			try
			{
				string messages = "";
				if (myCard.Id > 0)
				{

					_db.cards.Update(myCard);
					messages = "record update";
			      	
				}
				else {
					await _db.cards.AddAsync(myCard);
					
					messages = "record create";
				}
				await _db.SaveChangesAsync();
				return messages;
			}
			catch (Exception)
			{

				return "-500";
			}
		}

		public async Task<card> GetCardById(int id)
		{
			
				var card = await _db.cards.FindAsync(id);
				return card;
			
			
		}

		public async Task<List<card>> GetCards()
		{
			var list = await _db.cards.ToListAsync();
			return list;
		}

		public async Task<string> removeCard(int id)
		{
			try
			{

				var card = await _db.cards.FindAsync(id);
				if (card == null)
				{
					return "false";
				}
				_db.cards.Remove(card);
				await _db.SaveChangesAsync();
				return "true";


			}
			catch (Exception)
			{

				return "record dot exist";
			}		
		}
	}
}
