using SoundSystem;
using UnityEngine;

namespace ButtonAction
{
    class ReadMusicMute : MonoBehaviour
    {
        [SerializeField] GameObject PlusIcon;
        private void Start()
        {
            SoundManager.Instance.Music.OnSwitchMute += OnSwitchMute;
        }

        void OnSwitchMute(bool mute)
        {
            PlusIcon.SetActive(!mute);
        }

        private void OnDestroy()
        {
            SoundManager.Instance.Music.OnSwitchMute -= OnSwitchMute;
        }
    }
}
