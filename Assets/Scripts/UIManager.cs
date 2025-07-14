using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject mainMenuUI;
    public GameObject pausedUI;
    public GameObject playingUI;
    public GameObject gameOverUI;


    private void Awake()
    {
        // Ensure that there is only one instance of GameManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    public void ChangeUI(GameManager.GameState newState)
    {
        // Hide other UIs
        mainMenuUI.SetActive(false);
        pausedUI.SetActive(false);
        playingUI.SetActive(false);
        gameOverUI.SetActive(false);
        // Logic to change the UI based on the new game state
        switch (newState)
        {
            case GameManager.GameState.MainMenu:
                //show main menu UI
                mainMenuUI.SetActive(true);
                break;
            case GameManager.GameState.Paused:
                // Show paused UI
                pausedUI.SetActive(true);
                break;
            case GameManager.GameState.Playing:
                // Show playing UI
                playingUI.SetActive(true);
                break;
            case GameManager.GameState.GameOver:
                // Show game over UI
                gameOverUI.SetActive(true);
                break;
        }
    }
}
