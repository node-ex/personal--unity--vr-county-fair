using UnityEngine;

public class StrongmanHammerBehavior : MonoBehaviour
{
    public float StrikeMultiplier => _strikeMultiplier;

    [SerializeField] private float _strikeMultiplier = 0.1f;
    [SerializeField] private Transform _centerOfMass;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _rigidbody.centerOfMass = _centerOfMass.localPosition;
    }
}
