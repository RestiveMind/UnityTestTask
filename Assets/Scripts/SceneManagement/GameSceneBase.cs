using Core;
using UnityEngine;

namespace SceneManagement
{
    public abstract class GameSceneBase : MonoBehaviour
    {
        public abstract void OnLoaded(ServiceController serviceController);
    }
}
