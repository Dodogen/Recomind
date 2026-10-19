namespace _Recomind.Scripts.Core
{
    public interface IInitializable
    {
        uint InitOrder { get; set; } //TODO make in all used system link with this property and serialized private variable
        void Initialize();
    }
}