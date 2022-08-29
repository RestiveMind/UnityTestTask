using Core;
using Gameplay;
using Gameplay.Input;
using Gameplay.ObjectFactory;
using Gameplay.Storage;
using SceneManagement;
using UnityEngine;

namespace UI.Gameplay
{
    public class GameplayScene : GameSceneBase
    {
        [SerializeField] private Camera _renderCamera;
        [SerializeField] private LevelParams _levelParams;
        [SerializeField] private GameplayHud _gameplayHud;

        public override void OnLoaded(ServiceController serviceController)
        {
            serviceController.AddService<IInputService>(new InputService(_renderCamera));
            serviceController.AddService<IStorageService>(new StorageService());
            
            var poolService = serviceController.AddService<IPoolService>(new PoolService());
            var objectFactory =
                serviceController.AddService<IObjectFactoryService>(new ObjectFactoryService(serviceController,
                    poolService));
            var gameplayService =
                serviceController.AddService<IGameplayService>(new GameplayService(objectFactory));
            gameplayService.StartLevel(_levelParams, new GenericSpawnStrategy());
            
            _gameplayHud.Init(gameplayService.Player);
        }
    }
}
