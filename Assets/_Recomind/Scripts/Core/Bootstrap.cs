using System.Linq;
using UnityEngine;

namespace _Recomind.Scripts.Core
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private IInitializable[] _initableSystems;
        
        private IInitializationContext _context;
        private bool _isInitialized;

        public IInitializationContext Context
        {
            get=>_context; 
            private set => _context = value;
        }
        
        private void Awake()
        {
            if (!_isInitialized) Initialize();
            
        }
        private void Initialize()
        {
            Context = new InitializationContext();

            var systems = _initableSystems
                .Where(s => s != null)
                .OrderBy(s => s.InitOrder)
                .ToList();

            foreach (var system in systems)
            {
                system.Validate();
                system.Initialize(Context);
                Context.Register(system);
            }

            _isInitialized = true;
        }
        
        public T GetSystem<T>() where T: class, IInitializable => _context.Get<T>();
    }
}