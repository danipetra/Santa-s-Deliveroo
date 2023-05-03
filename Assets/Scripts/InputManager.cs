/* Manager for player Input, I'll use the old input system, 
to be faster and given that the game's only platform will be the PC  */

using UnityEngine;
public class InputManager : MonoBehaviour
{  

    public Vector3 HandleMovement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 right = transform.right * x;
        Vector3 forward = transform.forward * z;

        return (forward + right).normalized;
    }

    public void HandleRotation(float targetAngle, float speed)
    {
        if(Input.GetMouseButton(2))
            targetAngle += Input.GetAxisRaw("Mouse X") * speed;  
    }

    public float HandleZoom()
    {
        return Input.GetAxisRaw("Mouse ScrollWheel");
    }

    public void HandleTacticalView()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Tactical mode");
        }
    }


    public void HandleInput(){
        if(Input.GetMouseButton(0))
        {
            Debug.Log("Select Santa or deselect santa");
        }

        if(Input.GetMouseButton(1))
        {
            Debug.Log("Send Santa");
        }
    }
}
