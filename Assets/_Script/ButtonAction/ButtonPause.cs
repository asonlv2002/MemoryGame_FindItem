using DG.Tweening;
using SoundSystem;
using UnityEngine;
using UnityEngine.UI;

namespace ButtonAction
{
    internal class ButtonPause : MonoBehaviour
    {
        [SerializeField] DOTweenAnimation a;
        [SerializeField] GameObject Panel;
        [SerializeField] float duration;
        Button button;

        private void Awake()
        {
            a.duration = duration;
            button = GetComponent<Button>();
            button.onClick.AddListener(Open);
        }

        void Open()
        {
            Panel.gameObject.SetActive(true);
            a.DORestartById("Open");
            Time.timeScale = 0f;
        }

        public void Close()
        {
            a.DORestartById("Close");
            Time.timeScale = 1f;
            Invoke(nameof(DisablePanel), duration);
        }

        private void OnDestroy()
        {
            button.onClick.RemoveAllListeners();
        }

        void DisablePanel()
        {
            Panel.gameObject.SetActive(false);
        }
    }
}
