using UnityEngine;

public enum Player
{
    Player1,
    Player2
}

public class GameManager : MonoBehaviour
{
    // Single Reference Static Variables
    public static GameManager Instance { get; private set;}

    // Score Variables
    private int player1Score = 0;
    private int player2Score = 0;

    // Ball Variables
    private Vector2 currentVelocity;
    public Rigidbody2D ballRigidbody;
    public float ballSpeed = 5f;

    // Win condition variable
    public int winScore = 5;


    // Unity Function
    private void Awake()
    {
        // Ensure that there is only one instance of GameManager
        if(Instance == null)
        {
            Instance = this;
            // Intermediate Unity Tip and Trick
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        ResetBall();
    }

    public void AddScore(Player player)
    {
        // How do I know who scored?
        if(player == Player.Player1)
        {
            player1Score++;
            UIManager.Instance.UpdateScore(Player.Player1, player1Score);
            // Check win condition
            if(player1Score >= winScore)
            {
                // Player 1 Wins!
                // Display a win message!
                UIManager.Instance.DisplayWinMessage(Player.Player1);
                // Stop!
                StopGame();
            }
        }
        else if(player == Player.Player2)
        {
            player2Score++;
            UIManager.Instance.UpdateScore(Player.Player2, player2Score);
            if(player2Score >= winScore)
            {
                // Player 2 Wins!
                // Display a win message!
                UIManager.Instance.DisplayWinMessage(Player.Player2);
                // Stop!
                StopGame();
            }
        }

        DisplayScores();
        ResetBall();
    }

    private void DisplayScores()
    {
        Debug.Log($"Player 1: {player1Score} - Player 2: {player2Score}");
    }

    private void ResetBall()
    {
        ballRigidbody.transform.position = Vector2.zero;
        
        // Randomly choose a direction for the ball to move horizontally (left or right)

        // Generate a random value between 0 and 1. If the value is 0, return -1. If the value
        // is not 0, return 1.
        float randX = Random.Range(0, 2) == 0 ? -1 : 1;
        // Add a slight vertical variation
        float randY = Random.Range(-0.5f, 0.5f);

        // Set the ball's velocity
        Vector2 direction = new Vector2(randX, randY).normalized;
        ballRigidbody.linearVelocity = direction * ballSpeed;
        SetCurrentVelocity(ballRigidbody.linearVelocity);
    }

    public Vector2 GetCurrentVelocity()
    {
        return currentVelocity;
    }

    public void SetCurrentVelocity(Vector2 velocity)
    {
        currentVelocity = velocity;
        ballRigidbody.linearVelocity = currentVelocity;
    }

    private void StopGame()
    {
        Time.timeScale = 0;
    }
}