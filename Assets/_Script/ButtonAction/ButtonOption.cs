using PopupSystem;
using UnityEngine;
using UnityEngine.UI;

namespace ButtonAction
{
    internal class ButtonOption : MonoBehaviour
    {
        Button button;

        private void Awake()
        {
            button= GetComponent<Button>();
            button.onClick.AddListener(OnClick);
        }

        void OnClick()
        {
            PopupManager.Instance.Option.Open();
        }

        private void OnDestroy()
        {
            button.onClick.RemoveAllListeners();
        }
    }
}
