using FiguresDotStore.ViewModels.Exceptions;

namespace FiguresDotStore.ViewModels
{
    public class Square : Figure
	{
		public override void Validate()
		{
			if (SideA < 0)
				throw new FigureValidationException("Square restrictions not met");

			if (SideA != SideB)
				throw new FigureValidationException("Square restrictions not met");
		}

		public override double GetArea() => SideA * SideA;
	}
}
