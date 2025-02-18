using System;
using UnityEngine;

public enum GameStateEnum
{
    Started,
    Playing,
    Paused,
    Quit
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public static event Action<GameStateEnum> GameStateChanged;

    public GameStateEnum GameState => _gameState;
    private GameStateEnum _gameState;

    public void UpdateGameState(GameStateEnum gameState)
    {
        if (_gameState == gameState)
        {
            return;
        }

        if (gameState == GameStateEnum.Quit)
        {
            QuitGame();
        }

        _gameState = gameState;
        GameStateChanged?.Invoke(gameState);
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
