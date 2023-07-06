using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using GameplaySystem;
internal class PopupWin : MonoBehaviour
{
    [SerializeField] Text _level;
    [SerializeField] Text _score;
    [SerializeField] Text _flipCount;

    [SerializeField] DOTweenAnimation aniamtion;
    private void Awake()
    {

    }
    private void Start()
    {
        GamePlayManager.Instance.ItemFound.OnEnoughItem += OnWin;
    }

    void OnWin()
    {
        var gamePlay = GamePlayManager.Instance;
        _level.text = gamePlay.BoardCreate.BoardInfor.Level.ToString();
        _score.text = gamePlay.BoardCreate.BoardInfor.CurrentScore.ToString();
        _flipCount.text = gamePlay.FlipCount.CountFlip.ToString();
        aniamtion.DORestart();
    }
}
