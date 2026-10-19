using System;
using _Recomind.Scripts.Configs;
using _Recomind.Scripts.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Recomind.Scripts.InitableSystems
{
    public class LevelManager: MonoBehaviour, IInitializable
    {
        public uint InitOrder { get; set; }
        
        [SerializeField] private LevelsConfig  levelsConfig;
        
        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void LoadLevel(int index)
        {
            var levelScene = levelsConfig.GetByIndex(index);
            SceneManager.LoadScene(levelScene.name, LoadSceneMode.Single);
        }
    }
}