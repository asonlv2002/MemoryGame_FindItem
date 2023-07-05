using UnityEngine;
namespace CardSystem
{
    internal class CardStateControl : MonoBehaviour
    {
        CardControl _card;
        public CardState CurrentState;
        public CardState FaceUp;
        public CardState FaceDown;
        private void Awake()
        {
            _card = GetComponent<CardControl>();
            FaceUp = new FaceUpState(this,_card);
            FaceDown = new FaceDownState(this,_card);
            CurrentState = FaceDown;

        }
        private void Start()
        {
            CurrentState.EnterState();
        }

        public void SwitchState()
        {
            CurrentState.SwitchState();
            CurrentState.EnterState();
        }

    }
}
