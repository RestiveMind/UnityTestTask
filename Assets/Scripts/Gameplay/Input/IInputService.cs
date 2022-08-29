using Core;
using UnityEngine;

namespace Gameplay.Input
{
    public interface IInputService : IService
    {
        InputActions.GameplayActions GameplayActions { get; }
        Vector3 GetMousePos();
    }
}
