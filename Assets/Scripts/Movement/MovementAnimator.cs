using UnityEngine;

public class MovementAnimator : MonoBehaviour
{
    const string IsRunning = nameof(IsRunning);

    private Animator _selfAnimator;

    private void Start()
    {
        _selfAnimator = GetComponent<Animator>();
    }
    public void Animate(Vector3 direction)
    {
        if (Mathf.Abs(direction.x) > 0 || Mathf.Abs(direction.z) > 0)
            _selfAnimator.SetBool(IsRunning, true);
        else
            _selfAnimator.SetBool(IsRunning, false);
    }
}
