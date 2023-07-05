using UnityEngine;
using UnityEngine.UI;

namespace CountSystem
{
    internal class CountItemUI : MonoBehaviour
    {
        [SerializeField] Text _tItem;
        int CountItem = 0;

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
        }

        private void OnDestroy()
        {
            MatchSystem.MatchManager.Instance.MatchingProcess.OnCorrect -= OnMatchItem;
        }
    }
}
