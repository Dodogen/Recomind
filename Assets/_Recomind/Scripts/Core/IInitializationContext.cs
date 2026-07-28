namespace _Recomind.Scripts.Core
{
    public interface IInitializationContext
    {
        T Get<T>() where T: class, IInitializable;
        void Register<T>(T system) where  T: class, IInitializable;
    }
}