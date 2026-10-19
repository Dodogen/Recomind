using _Recomind.Scripts.Core;
using UnityEngine;
using Screen = _Recomind.Scripts.Ui.Screens.Screen;

namespace _Recomind.Scripts.InitableSystems
{
    public class UiManager : MonoBehaviour, IInitializable
    {
        [Header("Screens")] 
        [SerializeField] private Screen[] screens;
        
        /*
        [SerializeField] private HudScreen hudScreen;
        [SerializeField] private LoadingScreen loadingScreen;
        [SerializeField] private MenuScreen mainMenuScreen;
        [SerializeField] private SettingsScreen settingsScreen;
        [SerializeField] private WinScreen winScreen;
        [SerializeField] private LoseScreen loseScreen;
        */
        
        public uint InitOrder { get; set; }
        public void Initialize()
        {
            foreach (var screen in screens)
            {
                screen.HideImmediately();
            }
        }

        public bool TryGetScreen<TScreen>(out TScreen screen) where TScreen : Screen
        {
            screen = null;
            
            foreach (var s in screens)
            {
                if (s is TScreen ts) screen = ts;
            }
            
            return screen != null;
        }
    }
}