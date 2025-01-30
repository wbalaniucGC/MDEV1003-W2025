using UnityEngine;

public class BallMovement : MonoBehaviour
{
    // Ball Movement Script will trigger Scoring functions as it hits a goal

    // Const Strings
    private const string PlayerTag = "Player";
    private const string Player1GoalTag = "Player1Goal";
    private const string Player2GoalTag = "Player2Goal";

    // Private Variables
    private Rigidbody2D rBody;

    private void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag(PlayerTag))
        {
            HandlePlayerCollision(other);
        }
        else if(other.gameObject.CompareTag(Player1GoalTag))
        {
            // Player 2 Scores!
            HandlePlayer1GoalCollision();
        }
        else if(other.gameObject.CompareTag(Player2GoalTag))
        {
            // Player 1 Score!
            HandlePlayer2GoalCollision();
        }
        else
        {
            HandleCeilingFloorCollision();
        }
    }

    private void HandlePlayerCollision(Collision2D other)
    {
        Vector2 currentVelocity = GameManager.Instance.GetCurrentVelocity();
        // currentVelocity = new Vector2(currentVelocity.x * -1, currentVelocity.y);
        float y = CalculateBounceAngle(transform.position, other.transform.position, other.collider.bounds.size.y);
        currentVelocity = new Vector2(currentVelocity.x * -1, y).normalized * GameManager.Instance.ballSpeed;
        // Calculate bounce angle

        GameManager.Instance.SetCurrentVelocity(currentVelocity);
    }

    private void HandlePlayer1GoalCollision()
    {
        // We have no scoring logic! Who handles scoring logic?
        // A: GameManager!
        GameManager.Instance.AddScore(Player.Player2);
    }

    private void HandlePlayer2GoalCollision()
    {
        GameManager.Instance.AddScore(Player.Player1);
    }

    private void HandleCeilingFloorCollision()
    {
        Vector2 currentVelocity = GameManager.Instance.GetCurrentVelocity();
        currentVelocity = new Vector2(currentVelocity.x, currentVelocity.y * -1);
        GameManager.Instance.SetCurrentVelocity(currentVelocity);
    }

    private float CalculateBounceAngle(Vector2 ballPos, Vector2 paddlePos, float paddleHeight)
    {
        return (ballPos.y - paddlePos.y) / paddleHeight * 7f;
    }
}
