using UnityEngine;

public class Station : MonoBehaviour
{
    [SerializeField] private Product _neededProduct;
    [SerializeField] private int _maxProducts;

    [SerializeField] private int _currentProductsCount;
    private bool MayTakeProduct => _currentProductsCount < _maxProducts;

    public int CurrentProductsCount => _currentProductsCount;
    public void TryTakeProduct(Carrier carrier)
    {
        if(MayTakeProduct && carrier.Products.Contains(_neededProduct))
        {
            carrier.TryGiveProduct(_neededProduct);
            _currentProductsCount++;
        }
    }
}
