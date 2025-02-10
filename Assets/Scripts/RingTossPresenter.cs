using TMPro;
using UnityEngine;

public class RingTossPresenter : MonoBehaviour
{
    [SerializeField] TMP_Text _scoreText;

    private RingTossBoothService _ringTossBoothService;

    void Awake()
    {
        _ringTossBoothService = FindFirstObjectByType<RingTossBoothService>();
        if (_ringTossBoothService == null)
        {
            throw new System.Exception("RingTossBoothService not found in scene");
        }

        _ringTossBoothService.ScoreUpdated += OnScoreUpdated;
    }

    private void OnScoreUpdated(int newScore)
    {
        _scoreText.text = $"Score: {newScore}";
    }
}
