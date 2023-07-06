
using UnityEngine;
using SceneSystem;
using UnityEngine.UI;
namespace ButtonAction
{
    internal class ButtonLoadScene : MonoBehaviour
    {
        [SerializeField] Scene _scene;
        Button button;
        private void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(OnClick);
        }
        void OnClick()
        {
            LoadScene.Instance.LoadIntoScene(_scene);
        }
        private void OnDestroy()
        {
            button.onClick.RemoveAllListeners();
        }
    }
}
