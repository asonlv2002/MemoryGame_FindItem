using CardSystem;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace MatchSystem
{
    internal class MatchingProcess : MonoBehaviour
    {
        CardControl _firstCard;
        CardControl _secondCard;

        public UnityAction OnCorrect;
        public UnityAction OnFail;
        public UnityAction OnMatch;
        public bool IsOnProcess { get; private set; }
        private void Awake()
        {
            IsOnProcess = false;
            OnCorrect += OnActiveCorrect;
            OnFail += OnActiveFail;
        }
        public void OnClickCard(CardControl cardControl)
        {
            GetCardTracking(cardControl);
            if (!IsEnterCheck()) return;
            OnMatchCheck();
        }

        public void GetCardTracking(CardControl cardTarget)
        {

            if (_firstCard == null)
            {
                _firstCard = cardTarget;
            }
            else
            {
                _secondCard = cardTarget;
            }

            if (_secondCard == _firstCard)
            {
                _secondCard = null;
            }
        }

        bool IsEnterCheck()
        {
            return !IsOnProcess && _secondCard;
        }

        void OnMatchCheck()
        {
            IsOnProcess = true;
            if (_secondCard.CardUI.Icon == _firstCard.CardUI.Icon)
            {
                StartCoroutine(WaitLoadFlip(OnCorrect));
            }
            else
            {
                StartCoroutine(WaitLoadFlip(OnFail));
            }
            OnMatch?.Invoke();
        }

        IEnumerator WaitLoadFlip(UnityAction action)
        {
            yield return new WaitUntil(() => _secondCard.CardSate.CurrentState.IsOnFlip == false);
            yield return new WaitForSeconds(0.5f);
            action?.Invoke();
        }



        void OnActiveCorrect()
        {
            Destroy(_secondCard.gameObject);
            Destroy(_firstCard.gameObject);
            ClearTempCard();
        }

        void OnActiveFail()
        {
            _secondCard.CardSate.SwitchState();
            _firstCard.CardSate.SwitchState();
            ClearTempCard();
        }
        void ClearTempCard()
        {
            _secondCard = null;
            _firstCard = null;
            IsOnProcess = false;
        }

    }
}
