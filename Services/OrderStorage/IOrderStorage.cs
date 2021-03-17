using FiguresDotStore.ViewModels;
using System.Threading.Tasks;

namespace FiguresDotStore.Services.OrderStorage
{
    public interface IOrderStorage
	{		
		public Task<decimal> Save(Order order);
	}

}
