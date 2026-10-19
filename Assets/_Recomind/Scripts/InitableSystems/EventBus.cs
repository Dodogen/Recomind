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

        public void Subscribe<TEventData>(Action<TEventData> handler) where TEventData: struct
        {
            if (!_handlers.TryGetValue(typeof(TEventData), out var list))
            {
                list = new();
                _handlers[typeof(TEventData)] = list;
            }
            list.Add(handler);
        }

        public void Unsubscribe<TEventData>(Action<TEventData> handler) where TEventData: struct
        {
            if (_handlers.TryGetValue(typeof(TEventData), out var list))
            {
                list.Remove(handler);
            }
        }

        public void Publish<TEventData>(TEventData eventData) where TEventData: struct
        {
            if (_handlers.TryGetValue(typeof(TEventData), out var list))
            {
                list.ForEach(handler => ((Action<TEventData>)handler)?.Invoke(eventData));
            }
        }
    }
}