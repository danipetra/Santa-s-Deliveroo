using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    /* Variables for moving */
    [SerializeField, Range(5f, 20f)] private float _moveSpeed;
    [SerializeField, Range(5f, 10f)] private float _moveSmoothness;
    [SerializeField] private Vector2 _moveRange = new (100, 100);
    private Vector3 _targetPosition;
    private Vector3 _input;

    private InputManager inputManager;

    private void Awake() {
        inputManager = GetComponentInParent<InputManager>();

        _targetPosition = transform.position;
    }


    
    void Update()
    {
        _input = inputManager.HandleMovement();
        Move();
    }

    public void Move()
    {
        Vector3 nextTargetPosition = _targetPosition + _input * _moveSpeed;
        if(IsInBounds(nextTargetPosition)) _targetPosition = nextTargetPosition;
        transform.position = Vector3.Lerp(transform.position, _targetPosition, Time.deltaTime * _moveSmoothness);
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
