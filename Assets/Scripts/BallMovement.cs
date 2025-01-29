using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Rigidbody2D rBody;

    private const string PlayerTag = "Player";
    private const string Player1GoalTag = "Player1Goal";
    private const string Player2GoalTag = "Player2Goal";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        GameManager.Instance.ResetBall();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(PlayerTag))
        {
            HandlePlayerCollision(other);
        }
        else if (other.gameObject.CompareTag(Player1GoalTag) || other.gameObject.CompareTag(Player2GoalTag))
        {
            HandleGoalCollision(other);
        }
        else
        {
            HandleWallCollision();
        }

        rBody.linearVelocity = GameManager.Instance.GetCurrentVelocity();
    }

    private void HandlePlayerCollision(Collision2D other)
    {
        Vector2 currentVelocity = GameManager.Instance.GetCurrentVelocity();
        float y = CalculateBounceAngle(transform.position, other.transform.position, other.collider.bounds.size.y);
        currentVelocity = new Vector2(currentVelocity.x * -1, y).normalized * GameManager.Instance.GetBallSpeed();
        GameManager.Instance.SetCurrentVelocity(currentVelocity);
    }

    private void HandleGoalCollision(Collision2D other)
    {
        if (other.gameObject.CompareTag(Player1GoalTag))
        {
            GameManager.Instance.AddScore(Player.Player2);
        }
        else if (other.gameObject.CompareTag(Player2GoalTag))
        {
            GameManager.Instance.AddScore(Player.Player1);
        }
    }

    private void HandleWallCollision()
    {
        Vector2 currentVelocity = GameManager.Instance.GetCurrentVelocity();
        currentVelocity = new Vector2(currentVelocity.x, currentVelocity.y * -1);
        GameManager.Instance.SetCurrentVelocity(currentVelocity);
    }

    private float CalculateBounceAngle(Vector2 ballPos, Vector2 paddlePos, float paddleHeight)
    {
        return (ballPos.y - paddlePos.y) / paddleHeight * 3f; // Adjust the multiplier for desired bounce effect
    }
}
