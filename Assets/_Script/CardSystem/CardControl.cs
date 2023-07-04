using UnityEngine;

namespace CardSystem
{
    internal class CardControl : MonoBehaviour
    {
        public OnClickCardControl OnClickCard { get; private set; }
        public CardUI CardUI { get; private set; }
        private void Awake()
        {
            OnClickCard = GetComponent<OnClickCardControl>();
            CardUI = GetComponent<CardUI>();
        }
    }
}
