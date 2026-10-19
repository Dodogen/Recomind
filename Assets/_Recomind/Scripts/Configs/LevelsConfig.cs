using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Recomind.Scripts.Configs
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Configs/Levels Config")]
    public class LevelsConfig : ScriptableObject
    {
        public List<Scene> Levels = new();

        public Scene GetByIndex(int index)
        {
            return Levels[index];
        }
}
}