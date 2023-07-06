using UnityEngine;
using DG.Tweening;
using GameplaySystem;

internal class ClosePopup : MonoBehaviour
{

    [SerializeField] DOTweenAnimation aniamtion;
    private void Start()
    {
        GamePlayManager.Instance.Score.OnZerScore += OnLose;
    }

    void OnLose()
    {
        aniamtion.DORestart();
    }
}
