using FiguresDotStore.Services.OrderService;
using FiguresDotStore.ViewModels;
using FiguresDotStore.ViewModels.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace FiguresDotStore.Controllers
{
    [ApiController]
	[Route("[controller]")]
	public class FiguresController : ControllerBase
	{
		private readonly ILogger<FiguresController> _logger;		
		private readonly IOrderService _orderService;

		private const string MsgOrder = "Оформление заказа";
		private const string MsgFigureNotAvailable = "Товара нет в полном объеме";
		private const string MsgException = "Ошибка при оформлении заказа";

		public FiguresController(ILogger<FiguresController> logger, IOrderService orderService)
		{
			_logger = logger;					
			_orderService = orderService;
		}

		/// <summary>
		/// Оформление заказа 
		/// </summary>
		/// <param name="cart">Корзина покупателя</param>
		/// <returns>Стоимость заказа</returns>
		[HttpPost]
		public async Task<IActionResult> Order(Cart cart)
		{
			try
			{
				_logger.LogInformation(MsgOrder, cart.ToString());
				decimal sum = await _orderService.OrderFigures(cart);
				return Ok(sum);
			}
			catch (FigureValidationException ex)
			{
				_logger.LogInformation(ex.Message);
				return BadRequest(ex.Message);
			}
			catch (FigureNotAvailableException)
			{				
				_logger.LogInformation(MsgFigureNotAvailable);
				return BadRequest(MsgFigureNotAvailable);
			}
			catch (Exception ex)
			{
                _logger.LogError(ex, MsgException);
				return BadRequest(MsgException);
			}
		}
	}
}
