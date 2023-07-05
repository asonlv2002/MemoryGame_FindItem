namespace CardSystem
{
    internal abstract class CardState
    {
        protected CardControl Card;
        protected CardStateControl StateControl;
        private CardControl cardControl;
        public bool IsOnFlip;

        public CardState( CardStateControl cardState,CardControl cardControl)
        {
            Card = cardControl;
            StateControl = cardState;
        }

        public virtual void EnterState() { }
        public virtual void SwitchState() { }
    }
}
