using System.Collections.Generic;
using System.Linq;

namespace FiguresDotStore.ViewModels
{
    public class Order
	{
		public List<OrderFigure> Positions { get; set; }

		public decimal GetTotal() => Positions.Sum(x => (decimal)x.Figure.GetArea() * x.Count);
				
	}
}
