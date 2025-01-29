using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public string inputAxis;


    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis(inputAxis) * moveSpeed * Time.deltaTime;
        transform.Translate(0, move, 0);

        // Clamp the paddle's position to stay within the screen bounds
        float campedY = Mathf.Clamp(transform.position.y, -4.5f, 4.5f);
        transform.position = new Vector3(transform.position.x, campedY, transform.position.z);
    }
}
