using UnityEngine.InputSystem;
using UnityEngine;
using System.Collections.Generic;
using Gameplay.Input;
using Gameplay.ObjectFactory;

namespace Gameplay.Components
{
    public class PlayerMovementComponent : MonoBehaviour
    {
        private const float Speed = 15f;
        
        [SInject] private readonly IInputService _input = null;

        private bool _isDragStarted;
        private bool _isDragPerformed;

        private Queue<Vector2> _targetPath;
        private Vector2 _nextTarget;

        private void Start()
        {
            _input.GameplayActions.MouseClick.started += OnClickStarted;
            _input.GameplayActions.MouseClick.canceled += OnClickCanceled;
            _input.GameplayActions.DragScreen.performed += OnDragScreen;

            _targetPath = new Queue<Vector2>();
        }

        private void Update()
        {
            if(_nextTarget.Equals(transform.position) &&
               _targetPath.Count > 0)
            {
                _nextTarget = _targetPath.Dequeue();
            }
            if(!_nextTarget.Equals(transform.position))
            {
                var deltaDistance = Time.deltaTime * Speed;
                transform.position = Vector2.MoveTowards(transform.position, _nextTarget, deltaDistance);
            }
        }

        private void OnClickStarted(InputAction.CallbackContext obj)
        {
            _isDragStarted = true;
        }

        private void OnClickCanceled(InputAction.CallbackContext obj)
        {
            if(!_isDragPerformed)
            {
                ClearPath();
                EnqueueTarget(_input.GetMousePos());
            }
            _isDragStarted = false;
            _isDragPerformed = false;
        }

        private void OnDragScreen(InputAction.CallbackContext obj)
        {
            if(_isDragStarted)
            {
                _isDragPerformed = true;
                EnqueueTarget(_input.GetMousePos());
            }
        }

        private void ClearPath()
        {
            _targetPath.Clear();
        }

        private void EnqueueTarget(Vector2 targetPos)
        {
            if(_targetPath.Count == 0)
            {
                _nextTarget = targetPos;
            }
            _targetPath.Enqueue(targetPos);
        }
    }
}
