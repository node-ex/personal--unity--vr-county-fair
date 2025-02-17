using UnityEngine;

public class StrongmanStrikePadBehavior : MonoBehaviour
{
    private StrongmanService _strongmanService;

    private void Awake()
    {
        _strongmanService = FindFirstObjectByType<StrongmanService>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Hammer"))
        {
            return;
        }

        var hammerRigidbody = collision.gameObject.GetComponentInParent<Rigidbody>();
        /* Multiple types of hammers may be used for the strike */
        var hammerBehavior = collision.gameObject.GetComponentInParent<StrongmanHammerBehavior>();

        _strongmanService.Strike(hammerRigidbody.mass, collision.relativeVelocity.magnitude, hammerBehavior.StrikeMultiplier);
    }
}
