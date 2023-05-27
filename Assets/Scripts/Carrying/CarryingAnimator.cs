using UnityEngine;

[RequireComponent(typeof(Carrier), typeof(Animator))]
public class CarryingAnimator : MonoBehaviour
{
    const string IsCarrying = nameof(IsCarrying);

    private Carrier _carrier;
    private Animator _selfAnimator;
    private bool isCarrying => _carrier.Products.Count > 0;

    private void Start()
    {
        _carrier = GetComponent<Carrier>();
        _selfAnimator = GetComponent<Animator>();
        _carrier.OnChangeProducts.AddListener(SetAnimation);
    }
    private void SetAnimation()
    {
        _selfAnimator.SetBool(IsCarrying, isCarrying);
    }
}
