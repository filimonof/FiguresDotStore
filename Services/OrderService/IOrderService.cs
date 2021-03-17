using FiguresDotStore.ViewModels;
using System.Threading.Tasks;

namespace FiguresDotStore.Services.OrderService
{
    public interface IOrderService
    {
        public Task<decimal> OrderFigures(Cart cart);
    }
}
