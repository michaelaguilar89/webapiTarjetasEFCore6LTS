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
				var list = await _cardRepository.GetCards();
				_myresponse.Result = list;
				_myresponse.DisplayMessages = "List of Cards";

				return Ok(_myresponse);
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
				var messages = await _cardRepository.createUpdateCard(mycard);
				if (messages.Equals("create"))
				{
					_myresponse.DisplayMessages = "New record create";
					_myresponse.IsSucces = true;

					return Ok(_myresponse);
				}
				if (messages.Equals("-500"))
				{
					_myresponse.DisplayMessages = "Error on Create";
					return BadRequest(_myresponse);
				}
				_myresponse.DisplayMessages = "error";
				_myresponse.errorMessages = new List<string> { messages };
				return BadRequest(_myresponse);
			}
			catch (Exception e)
			{
				_myresponse.errorMessages = new List<string> { e.Message };
				return BadRequest(_myresponse);
			}
		}

		[HttpPut]
		public async Task<ActionResult> UpdateCard(card mycard)
		{
			try
			{

				var messages = await _cardRepository.createUpdateCard(mycard);
				if (messages.Equals("update"))
				{

					_myresponse.DisplayMessages = "record update Id : " + mycard.Id;
					_myresponse.IsSucces = true;
					return Ok(_myresponse);
				}
				if (messages.Equals("-500"))
				{
					_myresponse.DisplayMessages = "Error on update";
					return BadRequest(_myresponse);
				}
				_myresponse.DisplayMessages = "error fuera de ruta";
				_myresponse.errorMessages = new List<string> { messages };
				return BadRequest(_myresponse);
			}
			catch (Exception e)
			{
				_myresponse.errorMessages = new List<string> { e.Message };
				return BadRequest(_myresponse);
			}
		}

		[HttpGet("{id}")]
		public async Task<ActionResult> GetCardById(int id)
		{

			try
			{
				var card = await _cardRepository.GetCardById(id);
				if (card == null)
				{
					_myresponse.DisplayMessages = "the record does not exist";
					_myresponse.IsSucces = false;
					return Ok(_myresponse);
				}
				_myresponse.Result = card;
				_myresponse.IsSucces = true;
				return Ok(_myresponse);
			}
			catch (Exception e)
			{
				_myresponse.errorMessages = new List<string> { e.Message };
				return BadRequest(_myresponse);
			}
		}

		[HttpDelete]
		public async Task<ActionResult> removeCard(int id)
		{
			try
			{
				var messages = await _cardRepository.removeCard(id);
				if (messages=="false")
				{
					_myresponse.DisplayMessages = "This record does not exist!";
					_myresponse.IsSucces = false;
					return BadRequest(_myresponse);
				}
				if (messages=="true")
				{
					_myresponse.DisplayMessages = "Record Deleted";
					_myresponse.IsSucces = true;
					return Ok(_myresponse);
				}
				if (messages=="-500")
				{
					_myresponse.DisplayMessages = "Error internal server";
					_myresponse.IsSucces = false;
					return BadRequest(_myresponse);
				}
				_myresponse.DisplayMessages = "error";
				return BadRequest(_myresponse);
			}
			catch (Exception e)
			{

				_myresponse.DisplayMessages = "Error";
				_myresponse.IsSucces = false;
				_myresponse.errorMessages = new List<string> { e.Message };
				return BadRequest(_myresponse);
			}

		}

	}
}
