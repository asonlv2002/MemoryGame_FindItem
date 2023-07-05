using UnityEngine;
using System.Collections;
using CardSystem;
namespace MatchSytem
{
    internal class MatchManager : MonoBehaviour
    { 
        public static MatchManager Instance { get; private set; }

        CardControl _firstCard;
        CardControl _secondCard;
        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        public void OnClickCard(CardControl cardControl)
        {
            GetCardTracking(cardControl);
            if (!_secondCard) return;

            if(_secondCard.CardUI.Icon == _firstCard.CardUI.Icon)
            {
                StartCoroutine(OnCheckCorrectAll());
            }
            else
            {
                StartCoroutine(OnCheckFailAll());
            }
        }

        IEnumerator OnCheckFailAll()
        {
            yield return new WaitUntil(() => _secondCard.CardSate.CurrentState.IsOnFlip == false);
            yield return new WaitForSeconds(0.5f);
            _secondCard.CardSate.SwitchState();
            _firstCard.CardSate.SwitchState();
            _secondCard = null;
            _firstCard = null;
        }
        IEnumerator OnCheckCorrectAll()
        {
            yield return new WaitUntil(() => _secondCard.CardSate.CurrentState.IsOnFlip == false);
            yield return new WaitForSeconds(0.5f);
            Destroy(_secondCard.gameObject);
            Destroy(_firstCard.gameObject);
            _secondCard = null;
            _firstCard = null;
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

            if(_secondCard == _firstCard)
            {
                _secondCard = null;
            }
        }
    }
}

