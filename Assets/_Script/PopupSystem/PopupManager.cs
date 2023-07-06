
using UnityEngine;

namespace PopupSystem
{
    internal class PopupManager : MonoBehaviour
    {
        public static PopupManager Instance { get; private set; }
        [field : SerializeField] public PopupOption Option { get; private set; }
        private void Awake()
        {
            CreateInstance();
        }

        void CreateInstance()
        {
            if(Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }else
            {
                Destroy(gameObject);
            }
        }
    }
}
