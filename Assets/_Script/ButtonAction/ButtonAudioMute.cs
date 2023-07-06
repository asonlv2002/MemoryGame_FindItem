using SoundSystem;
using UnityEngine;
using UnityEngine.UI;

namespace ButtonAction
{
    internal class ButtonAudioMute : MonoBehaviour
    {
        Button button;

        private void Awake()
        {
            button = GetComponent<Button>();
        }
        private void Start()
        {
            button.onClick.AddListener(OnClick);
        }

        void OnClick()
        {
            SoundManager.Instance.Audio.Play(Audio.UIClick);
            SoundManager.Instance.Audio.SwitchMute();
        }

        private void OnDestroy()
        {
            button.onClick.RemoveAllListeners();
        }
    }
}
