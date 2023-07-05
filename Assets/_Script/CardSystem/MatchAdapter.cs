using UnityEngine;
using MatchSystem;
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
            var macthProcess = MatchManager.Instance.MatchingProcess;
            if (!macthProcess.IsOnProcess)
            {
                macthProcess.OnClickCard(_cardControl);
                _cardControl.CardSate.SwitchState();
            }

        }
    }
}
