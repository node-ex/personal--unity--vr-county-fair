using UnityEngine;

public class BalloonShooterPistolBehavior : MonoBehaviour
{
    [SerializeField] private Transform _raycastOrigin;
    [SerializeField] private float _maxShootDistance = 10f;

    private BalloonShooterBoothService _balloonShooterBoothService;

    public void Shoot()
    {
        RaycastHit hit;
        bool didHitSomething = Physics.Raycast(_raycastOrigin.position, _raycastOrigin.forward, out hit, _maxShootDistance);
        if (!didHitSomething || !hit.collider.CompareTag("Balloon"))
        {
            return;
        }

        hit.collider.gameObject.SetActive(false);
        _balloonShooterBoothService.PopBalloon();
    }

    private void Awake()
    {
        _balloonShooterBoothService = FindFirstObjectByType<BalloonShooterBoothService>();
    }
}
