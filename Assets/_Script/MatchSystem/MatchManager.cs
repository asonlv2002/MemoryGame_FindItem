using UnityEngine;
using CardSystem;
namespace MatchSytem
{
    internal class MatchManager : MonoBehaviour
    { 
        public static MatchManager Instance { get; private set; }

        CardControl _firstCard;
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
            if(_firstCard == null)
            {
                _firstCard = cardControl;
            }
            else
            if(_firstCard && _firstCard.CardUI.FaceUp == cardControl.CardUI.FaceUp)
            {
                Debug.Log("Correct");
                _firstCard = null;
            }else
            {
                _firstCard = null;
                Debug.Log("Fail");
            }
        }
    }
}

