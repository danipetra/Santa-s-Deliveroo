using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
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

    private InputManager _inputManager;
    private GameObject _cameraHolder;

    private void Awake() {
        _inputManager = GetComponent<InputManager>();

        _targetPosition = transform.position;

        _targetAngle = transform.eulerAngles.y;
        _currentAngle = _targetAngle;
    }


    
    private void Update()
    {
        _moveInput = _inputManager.HandleMovement();
        Move();

        _inputManager.HandleRotation(_targetAngle, _rotationSpeed);
        Rotate();
    }

    public void Move()
    {
        Vector3 nextTargetPosition = _targetPosition + _moveInput * _moveSpeed;
        if(IsInBounds(nextTargetPosition)) _targetPosition = nextTargetPosition;
        transform.position = Vector3.Lerp(transform.position, _targetPosition, Time.deltaTime * _moveSmoothness);
    }

    private void Rotate()
    {
        _currentAngle = Mathf.Lerp(_currentAngle, _targetAngle, Time.deltaTime * _rotationSmoothness);
        transform.rotation = Quaternion.AngleAxis(_currentAngle, Vector3.up);
    }

    private bool IsInBounds(Vector3 position)
    {
        return position.x > -_moveRange.x &&
               position.x < _moveRange.x &&
               position.z > -_moveRange.y &&
               position.z < _moveRange.y;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 5f);
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(_moveRange.x * 2f, 5f, _moveRange.y * 2f));    
    }
}
