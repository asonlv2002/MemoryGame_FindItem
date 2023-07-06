using UnityEngine;
using UnityEngine.UI;

namespace GameplaySystem
{
    internal class FlipCount : MonoBehaviour
    {
        [SerializeField] Text _tFlip;
        public int CountFlip { get; private set; }
        private void Awake()
        {
            CountFlip = 0;
            _tFlip.text = CountFlip.ToString();
        }
        private void Start()
        {
            MatchSystem.MatchManager.Instance.MatchingProcess.OnMatch += ReadFlipAction;
        }
        void ReadFlipAction()
        {
            CountFlip++;
            _tFlip.text = CountFlip.ToString();
        }

        private void OnDestroy()
        {
            MatchSystem.MatchManager.Instance.MatchingProcess.OnMatch -= ReadFlipAction;
        }
    }
}
