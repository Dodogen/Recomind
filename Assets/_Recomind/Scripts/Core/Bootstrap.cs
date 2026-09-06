using System.Linq;
using _Recomind.Scripts.Util;
using UnityEngine;

namespace _Recomind.Scripts.Core
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private IInitializable[] _initableSystems;
        
        private IInitializationContext _context;
        private bool _isInitialized;
        
        private void Awake()
        {
            if (!_isInitialized) Initialize();
        }
        private void Initialize()
        {
            _context = new InitializationContext();

            var systems = _initableSystems
                .Where(s => s != null)
                .OrderBy(s => s.InitOrder)
                .ToList();

            systems.ForEach(x=>
            {
                x.Initialize();
                _context.Register(x);
            });
            
            ServiceLocator.Initialize(_context);
            
            _isInitialized = true;
        }
    }
}