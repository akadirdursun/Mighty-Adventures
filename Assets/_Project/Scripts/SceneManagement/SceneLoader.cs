using System;
using DevLocker.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MightyAdventures.SceneManagement
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private SceneReference mainMenuScene;
        [SerializeField] private SceneReference gameScene;

        public void ReturnToMainMenu()
        {
            UnloadScene(gameScene);
            LoadScene(mainMenuScene);
        }

        public void LoadGameScene()
        {
            UnloadScene(mainMenuScene);
            LoadScene(gameScene);
        }

        private void LoadScene(SceneReference sceneReference, Action onComplete = null)
        {
            if (SceneLoaded(sceneReference)) return;
            var loadSceneAsync = SceneManager.LoadSceneAsync(sceneReference.ScenePath, LoadSceneMode.Additive);
            loadSceneAsync.completed += _ => onComplete?.Invoke();
        }

        private void UnloadScene(SceneReference sceneReference)
        {
            if (!SceneLoaded(sceneReference)) return;
            SceneManager.UnloadSceneAsync(sceneReference.ScenePath);
        }

        private bool SceneLoaded(SceneReference sceneReference)
        {
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                var scene = SceneManager.GetSceneAt(i);
                if (scene.path.Equals(sceneReference.ScenePath)) return true;
            }

            return false;
        }

        #region Monoehaviour Methods

        private void Start()
        {
            LoadScene(mainMenuScene);
        }

        #endregion
    }
}