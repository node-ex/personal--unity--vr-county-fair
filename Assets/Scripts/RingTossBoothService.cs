using System;
using UnityEngine;

public class RingTossBoothService : MonoBehaviour
{
    public event Action<int> ScoreUpdated;

    [SerializeField] private GameObject[] rings;
    [SerializeField] private int scorePerRing = 10;

    private int _score = 0;
    private Vector3[] _ringsStartingPositions;
    private Quaternion[] _ringsStartingRotations;

    void Start()
    {
        _ringsStartingPositions = new Vector3[rings.Length];
        _ringsStartingRotations = new Quaternion[rings.Length];
        for (int i = 0; i < rings.Length; i++)
        {
            _ringsStartingPositions[i] = rings[i].transform.position;
            _ringsStartingRotations[i] = rings[i].transform.rotation;
        }
    }

    public void AddToScore()
    {
        _score += scorePerRing;
        ScoreUpdated?.Invoke(_score);
    }

    [ContextMenu("Reset Ring Toss Game")]
    public void ResetGame()
    {
        _score = 0;
        ScoreUpdated?.Invoke(_score);

        for (int i = 0; i < rings.Length; i++)
        {
            rings[i].transform.SetPositionAndRotation(_ringsStartingPositions[i], _ringsStartingRotations[i]);
        }
    }
}
