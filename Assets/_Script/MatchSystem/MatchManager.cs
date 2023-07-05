using UnityEngine;
using System.Collections;
using CardSystem;
namespace MatchSystem
{
    internal class MatchManager : MonoBehaviour
    {
        public static MatchManager Instance { get; private set; }
        public MatchingProcess MatchingProcess { get; private set; }

        private void Awake()
        {
            CreateInstance();
            InitComponent();
        }

        void CreateInstance()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        void InitComponent()
        {
            MatchingProcess = GetComponent<MatchingProcess>();
        }
    }
}

