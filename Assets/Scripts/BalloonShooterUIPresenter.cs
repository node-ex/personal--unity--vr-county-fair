using System;
using TMPro;
using UnityEngine;

public class BalloonShooterUIPresenter : MonoBehaviour
{
    [SerializeField] private TMP_Text _stopwatchText;

    private BalloonShooterBoothService _balloonShooterBoothService;

    private void Awake()
    {
        _balloonShooterBoothService = FindFirstObjectByType<BalloonShooterBoothService>();
    }

    private void LateUpdate()
    {
        if (!_balloonShooterBoothService.IsStopwatchRunning)
        {
            return;
        }

        _stopwatchText.text = "Stopwatch: " + TimeSpan.FromSeconds(_balloonShooterBoothService.Stopwatch).ToString("mm\\:ss\\.fff");
    }
}
