using UnityEngine;
using UnityEngine.UI;

namespace GameplaySystem
{
    internal class ItemCollect : MonoBehaviour
    {
        [SerializeField] Image Icon;

        public void SetIcon(Sprite icon)
        {
            Icon.sprite = icon;
        }
    }
}
