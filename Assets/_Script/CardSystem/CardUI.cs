using UnityEngine;
using UnityEngine.UI;
namespace CardSystem
{
    internal class CardUI : MonoBehaviour
    {
        [SerializeField] Image _icon;
        [field: SerializeField] public RectTransform Transform { get; private set; }
        [field : SerializeField] public Sprite Icon { get;private set; }

        [field : SerializeField] public Sprite Thame { get; private set; }
        Image _backGround;
        private void Awake()
        {
            _backGround = GetComponent<Image>();
            Transform = GetComponent<RectTransform>();

            _backGround.sprite = Thame;
            Close();
        }

        public void Open()
        {
            _icon.gameObject.SetActive(true);
        }

        public void Close()
        {
            _icon.gameObject.SetActive(false);

        }

        public void SetIcon(Sprite icon)
        {
            Icon = icon;
            _icon.sprite = Icon;
        }
    }
}
