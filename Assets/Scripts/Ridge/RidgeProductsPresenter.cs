using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ridge))]
public class RidgeProductsPresenter : MonoBehaviour
{
    [SerializeField] private List<Transform> _productsPositions = new();
    private Ridge _ridge;
    private List<Product> _products = new();

    private void Start()
    {
        _ridge = GetComponent<Ridge>();
        InitializeProducts();
        _ridge.OnChangeProductCount.AddListener(UpdateProducts);
    }

    private void UpdateProducts()
    {
        ActivateProducts();
        DisactivateProducts();
    }
    private void InitializeProducts()
    {
        for (int i = 0; i < _ridge.MaxProductsCount; i++)
            _products.Add(Instantiate(_ridge.ProductPrefab, _productsPositions[i].position, Quaternion.identity, transform));
    }
    private void ActivateProducts()
    {
        foreach (var product in _products)
            product.gameObject.SetActive(true);
    }
    private void DisactivateProducts()
    {
        for(int i = _ridge.MaxProductsCount; i > _ridge.CurrectProductsCount; i--)
        {
            Product product = _products[i - 1];
            product.gameObject.SetActive(false);
        }
    }
}
