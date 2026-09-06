using System;
using System.Collections.Generic;
using _Recomind.Scripts.Core;
using UnityEngine;

namespace _Recomind.Scripts.InitableSystems
{
    public class EventBus : MonoBehaviour, IInitializable
    {
        public uint InitOrder { get; set; }
        
        private Dictionary<Type, List<Delegate>> _handlers;

        public void Initialize()
        {
            _handlers = new();
        }

        public void Subscribe<T>(Action<T> handler) where T: struct
        {
            if (!_handlers.TryGetValue(typeof(T), out var list))
            {
                list = new();
                _handlers[typeof(T)] = list;
            }
            list.Add(handler);
        }

        public void Unsubscribe<T>(Action<T> handler) where T: struct
        {
            if (_handlers.TryGetValue(typeof(T), out var list))
            {
                list.Remove(handler);
            }
        }

        public void Publish<T>(T eventData) where T: struct
        {
            if (_handlers.TryGetValue(typeof(T), out var list))
            {
                list.ForEach(handler => ((Action<T>)handler)?.Invoke(eventData));
            }
        }
    }
}