using UnityEngine;

public class MovementRotater : MonoBehaviour
{
    public void Rotate(Vector3 direction)
    {
        transform.LookAt(transform.position + direction);
    }
}
