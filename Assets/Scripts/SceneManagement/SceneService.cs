using System;
using Core;
using UnityEngine.SceneManagement;

namespace SceneManagement
{
    public class SceneService : ISceneService, IDisposable
    {
        public ServiceController ServiceController { private get; set; }

        public SceneService()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        public void Load(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            var loadedSceneRoot = UnityEngine.Object.FindObjectOfType<GameSceneBase>();

            if (loadedSceneRoot != null)
            {
                loadedSceneRoot.OnLoaded(ServiceController);
            }
        }

        public void Dispose()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}
