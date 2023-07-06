using CardSystem;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using GameplaySystem;
using SoundSystem;

namespace MatchSystem
{
    internal class MatchingProcess : MonoBehaviour
    {
        CardControl _firstCard;
        CardControl _secondCard;

        public UnityAction OnCorrect;
        public UnityAction OnFail;
        public UnityAction OnMatch;

        [SerializeField] RectTransform Containt;
        [SerializeField] Transform End;
        [SerializeField] ItemCollect itemPrefab;

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
                SoundManager.Instance.Audio.Play(Audio.CardClick);
            }
            else
            {

                if (cardTarget == _firstCard)
                {
                    _secondCard = null;
                    return;
                }
                _secondCard = cardTarget;
                SoundManager.Instance.Audio.Play(Audio.CardClick);
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
            SoundManager.Instance.Audio.Play(Audio.Correct);
            MoveToContaint(_secondCard);
            MoveToContaint(_firstCard);
            StartCoroutine(OnCreate(_firstCard));
            ClearTempCard();
        }

        void OnActiveFail()
        {
            SoundManager.Instance.Audio.Play(Audio.Fail);
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


        void MoveToContaint(CardControl cardControl)
        {
            var rect = cardControl.CardUI.Transform;
            var end = End.position;
            rect.DOMove(end, 0.5f).SetEase(Ease.InOutBack).OnComplete(() => Destroy(cardControl.gameObject));
        }

        IEnumerator OnCreate(CardControl cardControl)
        {
            var icon = cardControl.CardUI.Icon;
            yield return new WaitForSeconds(0.5f);
            var item = Instantiate(itemPrefab, Containt);
            item.SetIcon(icon);
        }
    }
}
