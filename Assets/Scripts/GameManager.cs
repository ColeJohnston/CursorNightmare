using UnityEngine;
using UnityEngine.Android;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public int maxScore = 0;

    public GameState currentGameState;

    public enum GameState
    {
        MainMenu,
        Paused,
        Playing,
        GameOver
    }

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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentGameState = GameState.MainMenu;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
