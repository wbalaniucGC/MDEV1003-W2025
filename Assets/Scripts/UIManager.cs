using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI player1ScoreText;
    [SerializeField] private TextMeshProUGUI player2ScoreText;

    private void Awake()
    {
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

    public void UpdateScore(Player player, int score)
    {
        if (player == Player.Player1)
        {
            player1ScoreText.text = score.ToString();
        }
        else if (player == Player.Player2)
        {
            player2ScoreText.text = score.ToString();
        }
    }
    public void DisplayWinMessage(Player player)
    {
        if (player == Player.Player1)
        {
            player1ScoreText.text = "Player 1 Wins!";
        }
        else if (player == Player.Player2)
        {
            player2ScoreText.text = "Player 2 Wins!";
        }
    }
}