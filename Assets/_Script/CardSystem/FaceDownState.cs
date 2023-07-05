using System.Collections;
using UnityEngine;

namespace CardSystem
{
    internal class FaceDownState : CardState
    {
        public FaceDownState(CardStateControl cardState, CardControl cardControl) : base(cardState, cardControl)
        {
        }
        public override void EnterState()
        {
            Card.StartCoroutine(FLipFaceDown());
        }
        public override void SwitchState()
        {
            StateControl.CurrentState = StateControl.FaceUp;
        }

        IEnumerator FLipFaceDown()
        {
            IsOnFlip = true;
            var Wait = new WaitForSeconds(0.01f);
            for (int i = 180; i > 0; i -= 5)
            {
                Card.CardUI.Transform.rotation = Quaternion.Euler(0, i, 0);
                if (i == 90)
                {
                    Card.CardUI.Close();
                }
                yield return Wait;
            }
            IsOnFlip = false;
        }
    }
}
