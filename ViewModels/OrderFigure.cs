using System;

namespace FiguresDotStore.ViewModels
{
    public class OrderFigure
    {
        public Figure Figure { get; set; }

        public int Count { get; set; }

        public OrderFigure(Position position)
        {
			Figure = position.Type switch
            {
                "Circle" => new Circle(),
                "Triangle" => new Triangle(),
                "Square" => new Square(),
                _ => throw new NotImplementedException()
            };

			Figure.SideA = position.SideA;
			Figure.SideB = position.SideB;
			Figure.SideC = position.SideC;

            Count = position.Count; 
        }
    }
}
