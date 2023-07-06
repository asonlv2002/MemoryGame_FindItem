using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;

namespace GameplaySystem
{
    internal class ScoreControl : MonoBehaviour
    {
        [SerializeField] Text _score;
        int Score;

        public UnityAction OnZerScore;

        private void Start()
        {
            Score = LevelSelect.LevelSelectSystem.Instance.BoardInformation.MaxScore;
            _score.text = Score.ToString();
        }

        public void StartGame()
        {
            StartCoroutine(ReduceScore());
        }

        IEnumerator ReduceScore()
        {
            var oneSeccond = new WaitForSeconds(1);
            while(Score >=0)
            {
                yield return oneSeccond;
                Score--;
                _score.text = Score.ToString();
            }
            yield return oneSeccond;
            OnZerScore?.Invoke();
            Debug.Log("Lose");
        }

        public void ReadScore()
        {
            LevelSelect.LevelSelectSystem.Instance.BoardInformation.SetMaxScore(Score);
            StopAllCoroutines();
        }

        private void OnDestroy()
        {
            ReadScore();
        }

    }
}
