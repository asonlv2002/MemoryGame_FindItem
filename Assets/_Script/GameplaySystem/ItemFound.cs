using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameplaySystem
{
    internal class ItemFound : MonoBehaviour
    {
        [SerializeField] Text _tItem;
        int CountItem = 0;
        public UnityAction OnEnoughItem;
        private void Start()
        {
            CountItem = 0;
            _tItem.text = CountItem.ToString();

            MatchSystem.MatchManager.Instance.MatchingProcess.OnCorrect += OnMatchItem;
        }

        void OnMatchItem()
        {
            CountItem++;
            _tItem.text = CountItem.ToString();
            if(CountItem >= LevelSelect.LevelSelectSystem.Instance.BoardInformation.Board.CardCount/2)
            {
                OnEnoughItem?.Invoke();
                Debug.Log("Win");
            }
        }

        private void OnDestroy()
        {
            MatchSystem.MatchManager.Instance.MatchingProcess.OnCorrect -= OnMatchItem;
        }
    }
}
