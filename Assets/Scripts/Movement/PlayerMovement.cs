using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider), typeof(MovementAnimator))]
[RequireComponent(typeof(MovementRotater))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _selfRigidBody;
    private MovementAnimator _selfMovementAnimator;
    private MovementRotater _selfMovementRotater;
    private Vector3 _normal;

    private void Start()
    {
        _selfRigidBody = GetComponent<Rigidbody>();
        _selfMovementAnimator = GetComponent<MovementAnimator>();
        _selfMovementRotater = GetComponent<MovementRotater>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        _normal = collision.contacts[0].normal;
    }

    private Vector3 ExpendDirectionAlongSurface(Vector3 direction)
    {
        return direction - Vector3.Dot(direction, _normal) * _normal;
    }
    public void Move(Vector3 direction)
    {
        Vector3 directionAlongSurface = ExpendDirectionAlongSurface(direction);
        Vector3 offset = directionAlongSurface * (_speed * Time.fixedDeltaTime);
        _selfRigidBody.MovePosition(_selfRigidBody.position + offset);
        _selfMovementAnimator.Animate(direction);
        _selfMovementRotater.Rotate(direction);
    }
}
