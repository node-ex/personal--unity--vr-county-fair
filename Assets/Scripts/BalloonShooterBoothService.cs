using UnityEngine;

public class BalloonShooterBoothService : MonoBehaviour
{
    [SerializeField] private GameObject[] _balloons;

    private int _balloonsPoppedCount = 0;

    public float Stopwatch => _stopwatch;
    private float _stopwatch = 0;

    public bool IsStopwatchRunning => _isStopwatchRunning;
    private bool _isStopwatchRunning = false;

    public void StartGame()
    {
        _isStopwatchRunning = true;
    }

    [ContextMenu("Reset Game")]
    public void ResetGame()
    {
        _balloonsPoppedCount = 0;
        _stopwatch = 0;

        foreach (GameObject balloon in _balloons)
        {
            balloon.SetActive(true);
        }
    }

    public void PopBalloon()
    {
        _balloonsPoppedCount += 1;
        if (_balloonsPoppedCount == _balloons.Length)
        {
            PauseGame();
        }
    }

    private void Update()
    {
        if (!_isStopwatchRunning)
        {
            return;
        }

        _stopwatch += Time.deltaTime;
    }

    private void PauseGame()
    {
        _isStopwatchRunning = false;
    }
}
