using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

namespace NonKipple.Core
{
    public class LoaderManager : Service
    {
        private Stopwatch initialTime;

        private void Start()
        {
            StartCoroutine(Initialize());
        }
        public override IEnumerator Initialize()
        {
            initialTime = new Stopwatch();
            initialTime.Start();

            var uiManager = serviceManager.GetManager<UIManager>();
            yield return StartCoroutine(uiManager.Initialize());
            UnityEngine.Debug.Log("UIManager initialized.");

            var gameManager = serviceManager.GetManager<GameManager>();
            yield return StartCoroutine(gameManager.Initialize());
            UnityEngine.Debug.Log("GameManager initialized.");

            var inputManager = serviceManager.GetManager<InputManager>();
            yield return StartCoroutine(inputManager.Initialize());
            UnityEngine.Debug.Log("InputManager initialized.");

            initialTime.Stop();

            UnityEngine.Debug.Log($"Initialize Time: {initialTime.ElapsedMilliseconds} ms");
        }
    }
}