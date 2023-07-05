using BoardSystem;
using LevelSelect;
using UnityEngine;
using UnityEngine.UI;

namespace GameplaySystem
{
    internal class CreatBoard : MonoBehaviour
    {
        BoardControl CurrentBoard;
        BoardInformation BoardInfor;
        public void CreateBoard()
        {
            BoardInfor = LevelSelectSystem.Instance.BoardInformation;
            var prefab = BoardInfor.Board;
            CurrentBoard = Instantiate(prefab, transform);
        }
    }
}
