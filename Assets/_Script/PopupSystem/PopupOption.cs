using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
namespace PopupSystem
{
    internal class PopupOption : MonoBehaviour
    {
        [SerializeField] DOTweenAnimation a;
        [SerializeField] GameObject Panel;
        [SerializeField] float duration;
        private void Awake()
        {
            a.duration = duration;
        }
        public void Open()
        {
            Panel.gameObject.SetActive(true);
            a.DORestartById("Open");
        }

        public void Close()
        {
            a.DORestartById("Close");

            Invoke(nameof(DisablePanel), duration);
        }

        void DisablePanel()
        {
            Panel.gameObject.SetActive(false);
        }
    }
}
