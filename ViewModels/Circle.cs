using FiguresDotStore.ViewModels.Exceptions;
using System;

namespace FiguresDotStore.ViewModels
{
    public class Circle : Figure
	{
		public override void Validate()
		{
			if (SideA < 0)
				throw new FigureValidationException("Circle restrictions not met");
		}

		public override double GetArea() => Math.PI * SideA * SideA;
	}

}
