using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody),typeof(Collider))]
public class FlyingProduct : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _selfRigidBody;
    [SerializeField] private Carrier _carrier;

    private void Start()
    {
        _selfRigidBody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        FlyToCarrier();
    }
    public void SetCarrier(Carrier carrier)
    {
        if (carrier == null)
            throw new InvalidOperationException();
        _carrier = carrier;
    }
    private void FlyToCarrier()
    {
        Vector3 direction = (_carrier.transform.position - transform.position).normalized;
        _selfRigidBody.AddForce(direction * _speed * Time.fixedDeltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Carrier carrier))
            Destroy(gameObject);
    }
}
