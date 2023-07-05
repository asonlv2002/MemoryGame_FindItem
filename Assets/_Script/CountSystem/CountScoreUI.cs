using UnityEngine;
using UnityEngine.UI;
namespace CountSystem
{
    internal class CountScoreUI : MonoBehaviour
    {
        [SerializeField] Text _tScore;
        int MaxScore;

        private void Start()
        {
            MaxScore = LevelSelect.LevelSelectSystem.Instance.BoardInformation.MaxScore;
            _tScore.text = MaxScore.ToString();
        }
    }
}
