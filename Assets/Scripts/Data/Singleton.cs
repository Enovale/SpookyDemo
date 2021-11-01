public class Singleton<T> where T : class, new()
{
    protected Singleton()
    {
    }

    public static readonly T Instance = new T();
}