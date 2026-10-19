using _Recomind.Scripts.Core;

namespace _Recomind.Scripts.Util
{
    public static class ServiceLocator
    {
        private static IInitializationContext _context;

        public static void Initialize(IInitializationContext context)
        {
            _context = context;
        }

        public static T GetSystem<T>() where T : class, IInitializable
        {
            return _context.Get<T>();
        }
    }
}