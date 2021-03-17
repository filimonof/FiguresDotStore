using FiguresDotStore.Services.RedisClient;
using FiguresDotStore.ViewModels.Exceptions;

namespace FiguresDotStore.Services.FiguresStorage
{
    public class FiguresStorage : IFiguresStorage
    {
		private readonly IRedisClient _redisClient;

		public FiguresStorage(IRedisClient redisClient)
		{
			_redisClient = redisClient;
		}

		public bool CheckIfAvailable(string type, int count)
		{
			return _redisClient.Get(type) >= count;
		}

		public void Reserve(string type, int count)
		{
			int current = _redisClient.Get(type);
			if (current < count)
			{
				throw new FigureNotAvailableException();
			}
			_redisClient.Set(type, current - count);
		}
	}
}
