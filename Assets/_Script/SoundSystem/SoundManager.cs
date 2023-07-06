using UnityEngine;

namespace SoundSystem
{
    internal class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance;
        public MusicControl Music;
        public AudioControl Audio;
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
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
