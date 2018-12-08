class SingletonManager<T> where T : new()
{
    static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance != null)
                return _instance;
            else
            {
                _instance = new T();
                return _instance;
            }
        }
    }

    public virtual void Init()
    {

    }

    public virtual void Uninit()
    {

    }
}