using _Recomind.Scripts.Core;
using UnityEngine;

namespace _Recomind.Scripts.InitableSystems
{
    public class SaveManager : MonoBehaviour, IInitializable
    {
        public uint InitOrder { get; set; }
        public void Initialize()
        {
            throw new System.NotImplementedException();
        }
    }
}