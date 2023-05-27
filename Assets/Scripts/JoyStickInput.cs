using UnityEngine;

public class JoyStickInput : MonoBehaviour
{
    [SerializeField] private PlayerMovement _movement;

    private DynamicJoystick _dynamicJoystick;
    private void Start()
    {
        _dynamicJoystick = GetComponent<DynamicJoystick>();
    }
    private void FixedUpdate()
    {
        float vertical = _dynamicJoystick.Vertical;
        float horizontal = _dynamicJoystick.Horizontal;

        _movement.Move(new Vector3(horizontal, 0, vertical));
    }
}
