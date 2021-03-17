using FiguresDotStore.Services.FiguresStorage;
using FiguresDotStore.Services.OrderStorage;
using FiguresDotStore.ViewModels;
using FiguresDotStore.ViewModels.Exceptions;
using System.Linq;
using System.Threading.Tasks;

namespace FiguresDotStore.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IFiguresStorage _figuresStorage;
        private readonly IOrderStorage _orderStorage;

        public OrderService(IFiguresStorage figuresStorage, IOrderStorage orderStorage)
        {
            _figuresStorage = figuresStorage;
            _orderStorage = orderStorage;
        }

        public async Task<decimal> OrderFigures(Cart cart)
        {
            Order order = new Order
            {
                Positions = cart.Positions.Select(x => new OrderFigure(x)).ToList()
            };

            order.Positions.ForEach(x => x.Figure.Validate());

            cart.Positions.ForEach(x =>
            {
                if (_figuresStorage.CheckIfAvailable(x.Type, x.Count))
                    throw new FigureNotAvailableException();
            });

            cart.Positions.ForEach(x => _figuresStorage.Reserve(x.Type, x.Count));

            return await _orderStorage.Save(order);
        }
    }
}
