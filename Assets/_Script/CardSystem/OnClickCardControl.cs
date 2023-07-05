using UnityEngine;
using UnityEngine.UI;
namespace CardSystem
{
    internal class OnClickCardControl : MonoBehaviour
    {
        CardControl _cardControl;
        Button _button;
        MatchAdapter _matchAdapter;
        private void Awake()
        {
            _cardControl = GetComponent<CardControl>();
            _button = GetComponent<Button>();
            _matchAdapter = new MatchAdapter(_cardControl);
            _button.onClick.AddListener(OnClick);
        }

        void OnClick()
        {
            _matchAdapter.OnClickCard();
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(OnClick);
        }
    }
}
