using UnityEngine;
using UnityEngine.Events;

namespace SoundSystem
{
    [System.Serializable]
    internal class MusicControl
    {
        [SerializeField] AudioSource themeSong;

        public UnityAction<bool> OnSwitchMute;
        public void SwitchMute()
        {
            themeSong.mute = !themeSong.mute;
            OnSwitchMute?.Invoke(themeSong.mute);
        }
    }
}
