using SoundSystem;
using UnityEngine;
using UnityEngine.UI;

namespace ButtonAction
{
    internal class ButtonMute : MonoBehaviour
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
            SoundManager.Instance.Music.SwitchMute();
        }

        private void OnDestroy()
        {
            button.onClick.RemoveAllListeners();
        }
    }
}
