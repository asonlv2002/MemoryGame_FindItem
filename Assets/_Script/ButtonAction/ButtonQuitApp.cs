using PopupSystem;
using SoundSystem;
using UnityEngine;
using UnityEngine.UI;

namespace ButtonAction
{
    internal class ButtonQuitApp : MonoBehaviour
    {
        Button button;

        private void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(OnClick);
        }

        void OnClick()
        {
            Application.Quit();
        }

        private void OnDestroy()
        {
            button.onClick.RemoveAllListeners();
        }
    }
}
