using Core;

namespace SceneManagement
{
    public interface ISceneService : IService
    {
        ServiceController ServiceController { set; }
        void Load(string sceneName);
    }
}
