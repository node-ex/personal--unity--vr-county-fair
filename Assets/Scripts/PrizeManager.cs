using UnityEngine;

public class PrizeManager : MonoBehaviour
{
    public static PrizeManager Instance { get; private set; }

    [SerializeField] private int _ringTossPrizeScore = 10;
    [SerializeField] private GameObject _ringTossTicketPrefab;
    [SerializeField] private Transform _ringTossTicketSpawnPoint;
    [SerializeField] private bool _hasSpawnedRingTossTicket = false;

    private RingTossBoothService _ringTossBoothService;

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

        _ringTossBoothService = FindFirstObjectByType<RingTossBoothService>();
    }

    private void Start()
    {
        _ringTossBoothService.ScoreUpdated += OnRingTossScoreUpdated;
    }

    private void OnDestroy()
    {
        _ringTossBoothService.ScoreUpdated -= OnRingTossScoreUpdated;
    }

    private void OnRingTossScoreUpdated(int score)
    {
        if (!_hasSpawnedRingTossTicket && score >= _ringTossPrizeScore)
        {
            Instantiate(_ringTossTicketPrefab, _ringTossTicketSpawnPoint.position, _ringTossTicketSpawnPoint.rotation);
            _hasSpawnedRingTossTicket = true;
        }
    }
}
