using System.Collections;
using UnityEngine;
namespace CardSystem
{
    internal class FaceUpState : CardState
    {
        public FaceUpState(CardStateControl cardState, CardControl cardControl) : base(cardState, cardControl)
        {
        }

        public override void EnterState()
        {
            Card.StartCoroutine(FLipFaceUp());
        }

        public override void SwitchState()
        {
            StateControl.CurrentState = StateControl.FaceDown;
        }

        IEnumerator FLipFaceUp()
        {
            IsOnFlip = true;
            var Wait = new WaitForSeconds(0.01f);
            for (int i = 0; i < 180; i+=5)
            {
                Card.CardUI.Transform.rotation = Quaternion.Euler(0, i, 0);
                if(i == 90)
                {
                    Card.CardUI.Open();
                }
                yield return Wait;
            }
            IsOnFlip = false;
        }
    }
}
