using UnityEngine;
using UnityEngine.UI;
namespace CardSystem
{
    internal class CardUI : MonoBehaviour
    {
        Image _face;
        [field : SerializeField] public Sprite FaceUp { get; private set; }
        [field : SerializeField] public Sprite FaceDown { get; private set; }
        private void Awake()
        {
            _face = GetComponent<Image>();
            _face.sprite = FaceUp;
        }
    }
}
