using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using WebApiTarjetas.Models;
using WebApiTarjetas.Repository_s;
using WebApiTarjetas.Response;

namespace WebApiTarjetas.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CardController : ControllerBase
	{
		private readonly CardInterface _cardRepository;
		protected response _myresponse;
		public CardController(CardInterface cardRepository)
		{
			_cardRepository = cardRepository;
			_myresponse = new response();
		}

		[HttpGet]
		public async Task<ActionResult> GetCards()
		{
			try
			{
			 var list= await _cardRepository.GetCards();
				_myresponse.Result = list;
				_myresponse.DisplayMessages = "List of Cards";
				return Ok(list);
			}
			catch (Exception e)
			{

				_myresponse.errorMessages = new List<string> { e.Message };
				_myresponse.DisplayMessages = "Error getCards";
				return BadRequest(_myresponse);
			}
		}

		[HttpPost]
		public async Task<ActionResult> CreateCard(card mycard)
		{
			try
			{
			  var messages=await _cardRepository.createUpdateCard(mycard);
				if (messages.Equals("record create"))
				{
					_myresponse.DisplayMessages = "New record create";
					_myresponse.IsSucces = true;
					
					return Ok(_myresponse);
				}
				if (messages.Equals("-500"))
				{
					_myresponse.DisplayMessages = "Error";
					return BadRequest(_myresponse);
				}
				_myresponse.DisplayMessages="error";
				return BadRequest(_myresponse);
			}
			catch (Exception e)
			{
				_myresponse.errorMessages = new List<string> { e.Message };
				return BadRequest(_myresponse);
			}
		}
	}
}
