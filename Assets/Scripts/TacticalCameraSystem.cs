    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class TacticalCameraSystem : MonoBehaviour
    {
        [Header ("Movement")]
        [SerializeField, Range(5f, 20f)] private float _moveSpeed;
        [SerializeField, Range(5f, 10f)] private float _moveSmoothness;
        [SerializeField] private Vector2 _moveRange = new (100, 100);
        private Vector3 _targetPosition;
        private Vector3 _moveInput;
        [Space(10)]

        [Header ("Rotation")]
        [SerializeField, Range(5f, 20f)] private float _rotationSpeed;
        [SerializeField, Range(5f, 10f)] private float _rotationSmoothness;
        private float _currentAngle;
        private float _targetAngle;
        private float _rotationInput;
        [Space(10)]

        [Header ("Zoom")]
        [SerializeField, Range(5f, 20f)] private float _zoomSpeed;
        [SerializeField, Range(5f, 10f)] private float _zoomSmoothness;
        private Vector2  _zoomRange = new(100f , 600f);
        
        [SerializeField] private Transform _cameraHolder;
        private Vector3 _cameraDirection => transform.InverseTransformDirection(_cameraHolder.forward);
        private Vector3 _zoomTargetPosition;
        private float _zoomInput;
        [Space(10)]

        private InputManager _inputManager;

        private void Awake() {
            _inputManager = GetComponent<InputManager>();

            _targetPosition = transform.position;

            _targetAngle = transform.eulerAngles.y;
            _currentAngle = _targetAngle;

            _zoomTargetPosition = _cameraHolder.localPosition;
        }


        
        private void Update()
        {
            _moveInput = _inputManager.HandleMovement();
            Move();

            _inputManager.HandleRotation(_targetAngle, _rotationSpeed);
            Rotate();

            _zoomInput = _inputManager.HandleZoom();
            Zoom();

        }

        public void Move()
        {
            Vector3 nextTargetPosition = _targetPosition + _moveInput * _moveSpeed;
            if(IsInPlanarBounds(nextTargetPosition)) _targetPosition = nextTargetPosition;
            transform.position = Vector3.Lerp(transform.position, _targetPosition, Time.deltaTime * _moveSmoothness);
        }

        private void Rotate()
        {
            _currentAngle = Mathf.Lerp(_currentAngle, _targetAngle, Time.deltaTime * _rotationSmoothness);
            transform.rotation = Quaternion.AngleAxis(_currentAngle, Vector3.up);
        }

        private void Zoom()
        {
            Vector3 nextTargetPosition = _zoomTargetPosition + _cameraDirection *(_zoomInput * _zoomSpeed);
            if(IsInYBounds(nextTargetPosition)) _zoomTargetPosition = nextTargetPosition;
        }

        private bool IsInPlanarBounds(Vector3 position)
        {
            return position.x > -_moveRange.x &&
                position.x < _moveRange.x &&
                position.z > -_moveRange.y &&
                position.z < _moveRange.y;
        }

        private bool IsInYBounds(Vector3 position)
        {
            return position.magnitude > _zoomRange.x && position.magnitude < _zoomRange.y;
        }

        private void OnDrawGizmos() {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, 5f);
            Gizmos.DrawWireCube(Vector3.zero, new Vector3(_moveRange.x * 2f, 5f, _moveRange.y * 2f));    
        }
    }
