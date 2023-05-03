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


    public void HandleInput(){

        if(Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Move up");
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Move Down");
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Move Left");
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Move Right");
        }
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Tactical mode");
        }
        
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Select Santa");
        }

        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            Debug.Log("Send Santa");
        }
    }
}
