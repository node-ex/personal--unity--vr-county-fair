using UnityEngine;

public class CarouselBehavior : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 1.0f;

    private void Update()
    {
        transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
    }
}
