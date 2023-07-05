using UnityEngine;
using BoardSystem;
namespace LevelSelect
{
    internal class LevelSelectSystem : MonoBehaviour
    {
        public static LevelSelectSystem Instance;
        public BoardInformation BoardInformation;
        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
                Debug.Log("Hello");
            }
            else
            {
                Destroy(gameObject);
            }
            
        }
    }
}
