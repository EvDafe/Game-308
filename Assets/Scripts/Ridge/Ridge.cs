using UnityEngine;
using UnityEngine.Events;

public class Ridge : MonoBehaviour
{
    [SerializeField] private int _maxProductsCount;
    [SerializeField] private float _maturationCooldown;
    [SerializeField] private Product _productPrefab;

    private int _currectProductsCount;
    private float _currentMaturationCooldown;
    public int MaxProductsCount => _maxProductsCount;
    public int CurrectProductsCount => _currectProductsCount;
    public Product ProductPrefab => _productPrefab;
    public UnityEvent OnChangeProductCount;
    public UnityEvent<Carrier> OnProductPickup;

    private void FixedUpdate()
    {
        MinusMaturationCooldown();
    }
    public void TryGiveProduct(Carrier carrier)
    {
        if (_currectProductsCount > 0)
        {
            carrier.TakeProduct(_productPrefab);
            _currectProductsCount -= 1;
            OnProductPickup?.Invoke(carrier);
            OnChangeProductCount?.Invoke();
        }
    }
    private void MinusMaturationCooldown()
    {
        _currentMaturationCooldown -= Time.fixedDeltaTime;
        if(_currentMaturationCooldown <= 0)
        {
            _currentMaturationCooldown = _maturationCooldown;
            Maturation();
        }
    }
    private void Maturation()
    {
        if (_currectProductsCount < _maxProductsCount)
        {
            _currectProductsCount++;
            OnChangeProductCount?.Invoke();
        }
    }

}
