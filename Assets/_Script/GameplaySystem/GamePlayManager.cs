using UnityEngine;
using System.Collections.Generic;
using BoardSystem;
using LevelSelect;
namespace GameplaySystem
{
    internal class GamePlayManager : MonoBehaviour
    {
        public static GamePlayManager Instance;

        public CreatBoard BoardCreate;
        public ScoreControl Score;
        public ItemFound ItemFound;
        private void Awake()
        {
            CreateInstance();
            BoardCreate = GetComponent<CreatBoard>();
            Score = GetComponent<ScoreControl>();
            ItemFound = GetComponent<ItemFound>();
        }

        private void Start()
        {
            ItemFound.OnEnoughItem += WinGame;
        }

        void CreateInstance()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        public void StartGame()
        {
            BoardCreate.CreateBoard();
            Score.StartGame();
        }

        void LoseGame()
        {

        }

        void WinGame()
        {
            Score.StopReduceScore();
        }    
    }
}
