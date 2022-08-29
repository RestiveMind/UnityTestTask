using SceneManagement;
using UnityEngine;

namespace Core
{
    public class ApplicationRoot : MonoBehaviour
    {
        [SerializeField] private string _gameplayScene = "Gameplay";

        private void Start()
        {
            var serviceControllerGo = new GameObject();
            var serviceController = serviceControllerGo.AddComponent<ServiceController>();
            
            var sceneService = serviceController.AddService<ISceneService>(new SceneService());
            sceneService.ServiceController = serviceController;
            sceneService.Load(_gameplayScene);
        }
    }
}

