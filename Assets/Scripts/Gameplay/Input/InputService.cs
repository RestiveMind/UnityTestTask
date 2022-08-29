using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay.Input
{
    public class InputService : IInputService
    {
        private readonly InputActions _actions;
        private readonly Camera _camera;

        public InputActions.GameplayActions GameplayActions => _actions.Gameplay;

        public InputService(Camera camera)
        {
            _camera = camera;
            _actions = new InputActions();
            _actions.Enable();
        }

        public Vector3 GetMousePos()
        {
            var mousePos = Mouse.current.position.ReadValue();
            return _camera.ScreenToWorldPoint(mousePos);
        }
    }
}
