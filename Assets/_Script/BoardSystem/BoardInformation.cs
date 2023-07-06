using UnityEngine;
namespace BoardSystem
{
    [CreateAssetMenu(fileName = "Board", menuName = "BoardCreate")]
    internal class BoardInformation : ScriptableObject
    {
        [field : SerializeField] public int Level { get; private set; }
        [field: SerializeField] public BoardControl Board { get; private set; }
        public int MaxScore;
        public int CurrentScore;

        public void SetMaxScore(int score)
        {
            if(score > CurrentScore) CurrentScore = score;
        }
    }
}
