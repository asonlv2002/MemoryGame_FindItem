using UnityEngine;
using MatchSytem;
namespace CardSystem
{
    internal class MatchAdapter
    {
        CardControl _cardControl;
        public MatchAdapter( CardControl cardControl)
        {
            _cardControl = cardControl;
        }

        public void OnClickCard()
        {
            MatchManager.Instance.OnClickCard(_cardControl);
        }
    }
}
