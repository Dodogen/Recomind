using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Recomind.Scripts.Core
{
    public class InitializationContext : IInitializationContext
    {
        private Dictionary<Type, IInitializable> _systems = new();
        
        public T Get<T>() where T : class, IInitializable =>
            _systems.TryGetValue(typeof(T), out var system) ? system as T : null;
        
        public void Register<T>(T system) where T : class, IInitializable
        {
            _systems.Add(system.GetType(), system);
            Debug.Log($"Registering. {system.GetType()} -> GetType() system | {typeof(T)} -> typeof() system");
        }
    }
}