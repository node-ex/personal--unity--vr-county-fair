using System.Collections;
using UnityEngine;

public class StrongmanService : MonoBehaviour
{
    [SerializeField] private Transform _sliderPosition;
    [SerializeField] private float _maxHeight = 6.6f;
    [SerializeField] private float _sliderMovementDurationInSeconds = 1.0f;
    [SerializeField] private float _sliderPauseDurationInSeconds = 1.0f;

    private float _initialHeight;
    private bool _isSliderMoving;

    public void Strike(float mass, float velocity, float strikeMultiplier)
    {
        Debug.Log($"Strike parameters - Mass: {mass}, Velocity: {velocity}, StrikeMultiplier: {strikeMultiplier}");

        if (_isSliderMoving)
        {
            return;
        }

        float impactForce = mass * velocity;

        float targetHeight = Mathf.Clamp(impactForce * strikeMultiplier, _initialHeight, _maxHeight);

        StartCoroutine(HandleSliderMovementUpAndDown(targetHeight));
    }

    private void Awake()
    {
        _initialHeight = _sliderPosition.position.y;
    }

    private IEnumerator HandleSliderMovementUpAndDown(float targetHeight)
    {
        _isSliderMoving = true;

        Vector3 startPosition = new Vector3(_sliderPosition.position.x, _initialHeight, _sliderPosition.position.z);
        Vector3 endPosition = new Vector3(_sliderPosition.position.x, targetHeight, _sliderPosition.position.z);

        /* Slider moving up */
        yield return StartCoroutine(MoveSlider(startPosition, endPosition, _sliderMovementDurationInSeconds));

        /* Slider paused */
        yield return new WaitForSeconds(_sliderPauseDurationInSeconds);

        /* Slider moving down */
        yield return StartCoroutine(MoveSlider(endPosition, startPosition, _sliderMovementDurationInSeconds));

        _isSliderMoving = false;
    }

    private IEnumerator MoveSlider(Vector3 from, Vector3 to, float duration)
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            _sliderPosition.position = Vector3.Lerp(from, to, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
