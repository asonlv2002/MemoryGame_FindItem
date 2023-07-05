using UnityEngine;
using UnityEngine.UI;

namespace CountSystem
{
    internal class LevelUI : MonoBehaviour
    {
        [SerializeField] Text _tLevel;

        private void Start()
        {
            _tLevel.text = LevelSelect.LevelSelectSystem.Instance.BoardInformation.Level.ToString();
        }
    }
}
