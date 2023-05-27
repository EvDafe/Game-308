using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Carrier : MonoBehaviour
{
    [SerializeField] private List<Product> _products = new();

    public UnityEvent OnChangeProducts;
    public List<Product> Products => _products;
    public void TakeProduct(Product product)
    {
        _products.Add(product);
        OnChangeProducts?.Invoke();
    }
    public void TryGiveProduct(Product product)
    {
        _products.Remove(product);
        Debug.Log("Чё за хня?");
        OnChangeProducts?.Invoke();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.TryGetComponent(out Ridge ridge))
        {
            ridge.TryGiveProduct(this);
        }
        if (other.TryGetComponent(out Station station))
        {
            station.TryTakeProduct(this);
        }
    }
}
