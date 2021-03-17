using FiguresDotStore.ViewModels.Exceptions;
using System;

namespace FiguresDotStore.ViewModels
{
    public class Triangle : Figure
	{
		public override void Validate()
		{
			bool CheckTriangleInequality(float a, float b, float c) => a < b + c;

			if (CheckTriangleInequality(SideA, SideB, SideC)
				&& CheckTriangleInequality(SideB, SideA, SideC)
				&& CheckTriangleInequality(SideC, SideB, SideA))
				return;

			throw new FigureValidationException("Triangle restrictions not met");
		}

		public override double GetArea()
		{
			var p = (SideA + SideB + SideC) / 2;
			return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
		}
	}
}
