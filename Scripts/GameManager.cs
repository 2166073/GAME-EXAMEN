using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Singleton pattern to ensure only one instance of GameManager exists

    public static GameManager Instance { get; private set; }

    [SerializeField] private Player player;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject gameOver;

    private int score;            // Current score
    public int Score => score;    // Property to access the score value


    private void Awake()
    {
        if (Instance != null)
        {
            // If an instance already exists, destroy the new GameManager

            DestroyImmediate(gameObject);
        }
        else
        {
            // Set this instance as the singleton instance
            Instance = this;
            // Set the target frame rate and ensure the GameManager persists across scenes
            Application.targetFrameRate = 60;
            DontDestroyOnLoad(gameObject);
            Pause();
        }
    }

    public void Play()
    {
        // Reset the score and update the UI text
        score = 0;
        scoreText.text = score.ToString();

        // Disable UI elements for play button and game over

        playButton.SetActive(false);
        gameOver.SetActive(false);

        // Set time scale to normal, enable player control, and clear existing pipes

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++) {
            // Destroy existing pipes

            Destroy(pipes[i].gameObject);
        }
    }

    public void GameOver()
    {
        // Show UI elements for play button and game over

        playButton.SetActive(true);
        gameOver.SetActive(true);

        // Pause the game

        Pause();
    }

    public void Pause()
    {
        // Pause the game by setting time scale to zero and disabling player control

        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void IncreaseScore()
    {
        // Increment the score and update the UI text

        score++;
        scoreText.text = score.ToString();
    }

}
