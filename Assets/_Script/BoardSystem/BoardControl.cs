using System.Collections.Generic;
using UnityEngine;
using CardSystem;
using UnityEngine.UI;

namespace BoardSystem
{
    internal class BoardControl : MonoBehaviour
    {
        [SerializeField] List<Sprite> _icons;
        [SerializeField] Vector2Int _sizeBoard;
        [SerializeField] float _sizeCard;
        [SerializeField] float _spaceCard;
        [SerializeField] RectTransform _startPos;
        [SerializeField] CardControl _cardPrefab;
        [SerializeField] List<CardControl> _cards;
        GridLayoutGroup grid;
        ContentSizeFitter _contentSizeFitter;
        int _cardCount => _sizeBoard.x * _sizeBoard.y;

        private void Awake()
        {
            _contentSizeFitter = GetComponent<ContentSizeFitter>();
            grid = GetComponent<GridLayoutGroup>();
        }

        private void Start()
        {
            _contentSizeFitter.enabled = true;
            grid.enabled = true;

            CreateBoard();
            ShuffleBoard();

            Invoke(nameof(this.DisableGrid), 1f);
        }

        void CreateBoard()
        {
            for(int i = 0; i < _cardCount; i++)
            {
                _cards.Add(Instantiate(_cardPrefab,transform));
            }
            for (int i = 0,indexIcon = 0 ; i < _cardCount; i+=2, indexIcon++)
            {
                _cards[i].CardUI.SetIcon(_icons[indexIcon]);
                _cards[i+1].CardUI.SetIcon(_icons[indexIcon]);
            }
        }

        void ShuffleBoard()
        {
            for(int i=0; i< _cardCount; i++)
            {
                Debug.Log(_cards[i]);
                var temp = _cards[i].CardUI.Icon;
                int randomIndex = Random.Range(i, _cardCount);
                Debug.Log(randomIndex);
                _cards[i].CardUI.SetIcon(_cards[randomIndex].CardUI.Icon);
                _cards[randomIndex].CardUI.SetIcon(temp);
            }
        }

        void DisableGrid()
        {
            _contentSizeFitter.enabled = false;
            grid.enabled = false;
        }
        
    }
}
