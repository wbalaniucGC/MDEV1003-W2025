using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public float moveSpeed = 10f;  
    public string paddleInputString = "PaddleLeft";
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Option 1: Fallback option for input handling
        /*
        if(Input.GetKey(KeyCode.W))
        {
            // Execute when player pressed the W key
            Debug.Log("I am pressing the W key");
        }
        if(Input.GetKey(KeyCode.S))
        {
            // Execute when player pressed the S key
            Debug.Log("I am pressing the S key.");
        }
        */


        
        // Option 2: Using Unity Input Manager
        float verticalInput = Input.GetAxis(paddleInputString); // A value between -1 and +1
        transform.Translate(Vector2.up * verticalInput * moveSpeed * Time.deltaTime);

        // Move my object on the Y-axis (up) based on the verticalInput value.

        
    }
}
