namespace FiguresDotStore.ViewModels
{
    public abstract class Figure
	{
		public float SideA { get; set; }
		
		public float SideB { get; set; }
		
		public float SideC { get; set; }

		public abstract void Validate();

		public abstract double GetArea();
	}
}
