using BoardSystem;
using LevelSelect;
using UnityEngine;
using UnityEngine.UI;

namespace GameplaySystem
{
    internal class CreatBoard : MonoBehaviour
    {
        public BoardControl CurrentBoard { get; private set; }
        public BoardInformation BoardInfor { get; private set; }
        public void CreateBoard()
        {
            BoardInfor = LevelSelectSystem.Instance.BoardInformation;
            var prefab = BoardInfor.Board;
            CurrentBoard = Instantiate(prefab, transform);
        }
    }
}
