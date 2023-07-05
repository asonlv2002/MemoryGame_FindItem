using UnityEngine;
using System.Collections.Generic;
using BoardSystem;
namespace GameplaySystem
{
    internal class GamePlayManager : MonoBehaviour
    {
        [field: SerializeField] public int CurrentLevel { get; private set; }
        [SerializeField] List<BoardInformation> _boardsInfor;
        BoardControl CurrentBoard;

        private void Awake()
        {
            
        }
        private void Start()
        {
            CreateBoard();
        }
        void CreateBoard()
        {
            var prefab = _boardsInfor.Find(x => x.Level == CurrentLevel).Board;
            CurrentBoard = Instantiate(prefab, transform);
        }
    }
}
