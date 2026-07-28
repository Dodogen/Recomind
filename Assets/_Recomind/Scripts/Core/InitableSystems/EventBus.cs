using _Recomind.Scripts.Core;
using UnityEngine;

namespace _Recomind.Scripts.InitableSystems
{
    public class EventBus : MonoBehaviour, IInitializable
    {
        public uint InitOrder { get; set; }
        public void Initialize(IInitializationContext context)
        {
            throw new System.NotImplementedException();
        }

        public void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}