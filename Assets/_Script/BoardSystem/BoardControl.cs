using System.Collections.Generic;
using System.Collections;
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
        public int CardCount => _sizeBoard.x * _sizeBoard.y;

        private void Awake()
        {
            _contentSizeFitter = GetComponent<ContentSizeFitter>();
            grid = GetComponent<GridLayoutGroup>();
        }

        private void Start()
        {
            _contentSizeFitter.enabled = true;
            grid.enabled = true;

            StartCoroutine(CreateBoard());
            Invoke(nameof(this.DisableGrid), 1f);
        }

        IEnumerator CreateBoard()
        {
            var wait = new WaitForSeconds(0.02f);
            for(int i = 0; i < CardCount; i++)
            {
                _cards.Add(Instantiate(_cardPrefab,transform));
                yield return wait;
            }
            for (int i = 0,indexIcon = 0 ; i < CardCount; i+=2, indexIcon++)
            {
                _cards[i].CardUI.SetIcon(_icons[indexIcon]);
                _cards[i+1].CardUI.SetIcon(_icons[indexIcon]);
            }
            ShuffleBoard();
        }

        void ShuffleBoard()
        {
            for(int i=0; i< CardCount; i++)
            {
                var temp = _cards[i].CardUI.Icon;
                int randomIndex = Random.Range(i, CardCount);
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
