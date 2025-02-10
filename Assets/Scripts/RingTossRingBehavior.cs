using System.Collections;
using UnityEngine;

public class RingTossRingBehavior : MonoBehaviour
{
    private RingTossBoothService _ringTossBoothService;
    private bool _isAroundBottle = false;

    void Awake()
    {
        _ringTossBoothService = FindFirstObjectByType<RingTossBoothService>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Bottle"))
        {
            return;
        }

        _isAroundBottle = true;
        StopAllCoroutines();
        StartCoroutine(ScoreDelay());
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Bottle"))
        {
            return;
        }

        _isAroundBottle = false;
    }

    IEnumerator ScoreDelay()
    {
        yield return new WaitForSeconds(3f);
        if (_isAroundBottle)
        {
            _ringTossBoothService.AddToScore();
        }
    }
}
