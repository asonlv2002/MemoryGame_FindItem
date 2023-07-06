using BoardSystem;
using UnityEngine;
using UnityEngine.UI;
using SceneSystem;
namespace LevelSelect
{
    internal class Level : MonoBehaviour
    {
        [SerializeField] Text _level;
        [SerializeField] Text _score;
        [SerializeField] BoardInformation boardInformation;
        Button _onClick;
        private void Awake()
        {
            InitInfor();
            _onClick = GetComponent<Button>();
            _onClick.onClick.AddListener(OnClick);
        }

        void InitInfor()
        {
            _level.text = boardInformation.Level.ToString();
            _score.text = boardInformation.CurrentScore.ToString();
        }

        void OnClick()
        {
            LevelSelectSystem.Instance.BoardInformation = boardInformation;
            LoadScene.Instance.LoadIntoScene(Scene.GamePlay);
        }

        private void OnDestroy()
        {
            _onClick.onClick.RemoveAllListeners();
        }
    }
}
