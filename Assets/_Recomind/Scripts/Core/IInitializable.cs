namespace _Recomind.Scripts.Core
{
    public interface IInitializable
    {
        uint InitOrder { get; set; }
        void Initialize();
    }
}