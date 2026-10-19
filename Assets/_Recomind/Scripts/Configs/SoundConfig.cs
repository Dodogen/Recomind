using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace _Recomind.Scripts.Configs
{
    [CreateAssetMenu(fileName = "SoundConfig", menuName = "Configs/Sound Config")]
    public class SoundConfig : ScriptableObject
    {
        [SerializeField] [Range(0f, 1f)] private float masterVolume;
        [SerializeField] [Range(0f, 1f)] private float sfxVolume;
        
        [SerializeField] private List<SoundItem> allSounds = new();
        
        public float MasterVolume
        {
            get => masterVolume;
            set => masterVolume = Math.Clamp(value, 0f, 1f);
        }

        public float SfxVolume
        {
            get => sfxVolume * masterVolume;
            set => masterVolume = Math.Clamp(value, 0f, 1f);
        }
        
        [CanBeNull]
        public SoundItem GetSoundItemById(SoundId soundId)
        {
            foreach (var sound in allSounds)
            {
                if(sound.Id == soundId) return sound;
            }
            return null;
        }
        
        private void OnValidate() //TODO: should optimize and not iterate on every value but only on changed 
        {
            foreach (var item in allSounds)
            {
                if (item.SoundType == SoundType.Sfx)
                {
                    item.Volume = SfxVolume;
                    continue;
                }
                item.Volume = MasterVolume;
            }
            
            //check for dupes of IDs except None
            var frequencyDict = allSounds.GroupBy(x => x.Id)
                .ToDictionary(x => x.Key, x => x.Count());
            
            if (frequencyDict.Count(x => x.Key != SoundId.None && x.Value > 1) > 0)
            {
                foreach (var f in frequencyDict)
                {
                    Debug.Log($"SoundId = {f.Key} is not unique. There are {f.Value} of them totally in sound list");
                }
            }
        }
    }
    
    [Serializable]
    public class SoundItem
    {
        public SoundId Id = SoundId.None;
        public SoundType SoundType =  SoundType.Master;
        public AudioClip AudioClip;
        [Range(0f,1f)] public float Volume; //TODO add dependence from master\sfx sounds
        
        //TODO add properties
        
        //TODO add pitch randomisation amplitude
        //TODO add method for setting random pitch on get 
    }
    
    public enum SoundType
    {
        Master,
        Sfx
    }

    // better to switch to custom property drawer and enum auto-generation
    public enum SoundId // need for get ID conveniently
    {
        None,
        BackgroundMenuMusic,
        BackgroundLevelMusic, // may be some items of like that type
        Jump,
        ButtonClick,
        PlayerDamageHit,
        PlayerAttackHit,
        //...
    }
}