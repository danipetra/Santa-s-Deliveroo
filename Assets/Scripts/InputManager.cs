/* Manager for player Input, I'll use the old input system, 
to be faster and given that the game's only platform will be the PC  */

using UnityEngine;
public class InputManager : MonoBehaviour
{    
    void Start()
    {
        
    }

    void Update()
    {
        CheckForPlayerInput();
    }

    private void CheckForPlayerInput()
    {
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
