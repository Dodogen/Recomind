using System;
using System.Collections.Generic;
using _Recomind.Scripts.Configs;
using _Recomind.Scripts.Core;
using UnityEngine;

namespace _Recomind.Scripts.InitableSystems
{
    public class AudioManager : MonoBehaviour, IInitializable
    {
        [SerializeField] private SoundConfig soundConfig;
        [SerializeField] private int audioSourcesPoolSize;
        
        private Queue<AudioSource> _audioSources;
        public uint InitOrder { get; set; }
        
        public void Initialize()
        {
            _audioSources = new Queue<AudioSource>();
            for (int i = 0; i < audioSourcesPoolSize; i++)
            {
                var go = new GameObject($"AudioSource_{i}");
                go.transform.SetParent(transform);
                var audioSource = go.AddComponent<AudioSource>();
                audioSource.playOnAwake = false;
                audioSource.spatialBlend = 0f;
                _audioSources.Enqueue(audioSource);
            }
        }

        public void PlayOnceById(SoundId soundId)
        {
            var clip = soundConfig.GetSoundItemById(soundId);
            //TODO make realisation
        }

        public void PlayLoopedById(SoundId soundId)
        {
            var clip = soundConfig.GetSoundItemById(soundId);
            //TODO make realisation
        }

        public void StopById(SoundId soundId)
        {
            var clip = soundConfig.GetSoundItemById(soundId);
            //TODO make realisation
        }
        public void PauseById(SoundId soundId)
        {
            var clip = soundConfig.GetSoundItemById(soundId);
            //TODO make realisation
        }

        public void SetVolumeForAllAudioOfType(SoundType type, float value)
        {
            switch (type)
            {
                case SoundType.Master: soundConfig.MasterVolume = value; break;
                case SoundType.Sfx: soundConfig.SfxVolume = value; break;
                default: Debug.LogError($"Sound type: {type} does not configured"); break;
            }
        }
    }
}