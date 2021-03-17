namespace FiguresDotStore.Services.RedisClient
{
    public interface IRedisClient
    {
        int Get(string type);

        void Set(string type, int current);
    }
}
