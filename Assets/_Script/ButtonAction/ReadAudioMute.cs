using SoundSystem;
using UnityEngine;

namespace ButtonAction 
{
    class ReadAudioMute : MonoBehaviour
    {
        [SerializeField] GameObject PlusIcon;
        private void Start()
        {
            SoundManager.Instance.Audio.OnSwitchMute += OnSwitchMute;
        }

        void OnSwitchMute(bool mute)
        {
            PlusIcon.SetActive(!mute);
        }

        private void OnDestroy()
        {
            SoundManager.Instance.Audio.OnSwitchMute -= OnSwitchMute;
        }
    }
}
