namespace FiguresDotStore.Services.FiguresStorage
{
    public interface IFiguresStorage
    {
		public bool CheckIfAvailable(string type, int count);

		public void Reserve(string type, int count);
	}
}
