using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

namespace SoundSystem
{
    [System.Serializable]
    internal class AudioControl
    {
        [SerializeField] bool _mute;
        [SerializeField] List<AudioConfig> audioConfigs;

        public UnityAction<bool> OnSwitchMute;
        public void Play(Audio audio)
        {
            if (_mute) return;
            var target = audioConfigs.Find(x => x.Audio == audio);
            target.AudioSource.Play();
        }

        public void SwitchMute()
        {
            _mute = !_mute;
            OnSwitchMute?.Invoke(_mute);
        }
    }

    public enum Audio
    {
        UIClick,
        CardClick,
        SwitchScene,
        Correct,
        Fail
    }

    [System.Serializable]
    internal class AudioConfig
    {
        public Audio Audio;
        public AudioSource AudioSource;
    }
}
