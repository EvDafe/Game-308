using UnityEngine;

[RequireComponent(typeof(Ridge))]
public class FlyingProductPresenter : MonoBehaviour
{
    [SerializeField] private FlyingProduct _flyingProductPrefab;

    private Ridge _ridge;
    private void Start()
    {
        _ridge = GetComponent<Ridge>();
        _ridge.OnProductPickup.AddListener(CreateFlyingProduct);
    }
    private void CreateFlyingProduct(Carrier carrier)
    {
        Instantiate(_flyingProductPrefab, transform.position, Quaternion.identity).SetCarrier(carrier);
    }
}
