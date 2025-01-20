using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float ballSpeed = 5f;
    private Rigidbody2D rBody;
    private Vector2 currentVelocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        ResetBall();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            // Colliding with a paddle (or player)
            currentVelocity = new Vector2(currentVelocity.x * -1, currentVelocity.y);
        }
        else if(other.gameObject.CompareTag("Goals"))
        {
            // Reset the ball to the middle
            ResetBall();
            // Score a point for the appropriate side.
        }
        else
        {
            currentVelocity = new Vector2(currentVelocity.x, currentVelocity.y * -1);
        }

        rBody.linearVelocity = currentVelocity;
    }

    private void ResetBall()
    {
        transform.position = Vector2.zero;
        float randX = Random.Range(-1, 1);
        float randY = Random.Range(-1, 1);
        rBody.linearVelocity = new Vector2(randX, randY) * ballSpeed;
        currentVelocity = rBody.linearVelocity;
    }
}
