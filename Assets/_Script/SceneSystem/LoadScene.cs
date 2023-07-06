﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;
namespace SceneSystem
{
    internal class LoadScene : MonoBehaviour
    {
        public static LoadScene Instance;
        [SerializeField] DOTweenAnimation a;
        [SerializeField] DOTweenAnimation b;
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

        public void LoadIntoScene(Scene scene)
        {
            StartCoroutine(WaitLoad(scene));
            a.DORestart();
            b.DORestart();
        }

        IEnumerator WaitLoad(Scene scene)
        {
            yield return new WaitForSeconds(0.4f);
            SceneManager.LoadScene(scene.ToString());
        }
    }

    public enum Scene
    {
        GroupLevel,
        GamePlay
    }
}