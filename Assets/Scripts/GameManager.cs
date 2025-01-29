using UnityEngine;

public enum Player
{
    Player1,
    Player2
}   

public class GameManager : MonoBehaviour
{
    // Implement Singleton pattern
    public static GameManager Instance { get; private set; }

    // Score Variables
    private int player1Score = 0;
    private int player2Score = 0;

    // Inspector Variables - Ball
    [SerializeField] private Rigidbody2D ballRigidbody;
    [SerializeField] private float ballSpeed = 5f;
    [SerializeField] private int winScore = 2;

    private Vector2 currentVelocity;


    private void Awake()
    {
        // Ensure that there is only one instance of GameManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ResetBall();
    }

    public void AddScore(Player player)
    {
        if (player == Player.Player1)
        {
            player1Score++;
            UIManager.Instance.UpdateScore(Player.Player1, player1Score);
            if(player1Score >= winScore)
            {
                UIManager.Instance.DisplayWinMessage(Player.Player1);
                StopGame();
                return;
            }
        }
        else if (player == Player.Player2)
        {
            player2Score++;
            UIManager.Instance.UpdateScore(Player.Player2, player2Score);
            if (player2Score >= winScore)
            {
                UIManager.Instance.DisplayWinMessage(Player.Player2);
                StopGame();
                return;
            }
        }
        // DisplayScores();
        ResetBall();
    }
    /*
    private void DisplayScores()
    {
        Debug.Log($"Player 1: {player1Score} - Player 2: {player2Score}");
    }
    */

    public void ResetGame()
    {
        player1Score = 0;
        player2Score = 0;
        UIManager.Instance.UpdateScore(Player.Player1, player1Score);
        UIManager.Instance.UpdateScore(Player.Player2, player2Score);   
        ResetBall();
        Time.timeScale = 1;
    }

    public void ResetBall()
    {
        ballRigidbody.transform.position = Vector2.zero;

        // Randomly choose a direction for the ball to move horizontally (left or right)
        float randX = Random.Range(0, 2) == 0 ? -1 : 1;
        // Add a slight vertical variation
        float randY = Random.Range(-0.5f, 0.5f);

        // Set the ball's velocity
        Vector2 direction = new Vector2(randX, randY).normalized;
        ballRigidbody.linearVelocity = direction * ballSpeed;
        currentVelocity = ballRigidbody.linearVelocity;
    }
    public Vector2 GetCurrentVelocity()
    {
        return currentVelocity;
    }

    public void SetCurrentVelocity(Vector2 velocity)
    {
        currentVelocity = velocity;
    }

    public float GetBallSpeed()
    {
        return ballSpeed;
    }

    private void StopGame()
    {
        Time.timeScale = 0; // Pause the game
    }
}
