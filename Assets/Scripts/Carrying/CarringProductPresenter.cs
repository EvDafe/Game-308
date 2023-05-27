using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Carrier))]
public class CarringProductPresenter : MonoBehaviour
{
    [SerializeField] private Transform _presentPosition;
    [SerializeField] private float _productsMargin;

    Carrier _selfCarrier;
    private List<Product> _products = new();

    private void Start()
    {
        _selfCarrier = GetComponent<Carrier>();
        _selfCarrier.OnChangeProducts.AddListener(UpdateProducts);
    }

    private void UpdateProducts()
    {
        DeleteProducts();
        CreateProducts();
    }
    private void CreateProducts()
    {
        for(int i = 0; i < _selfCarrier.Products.Count; i++)
        {
            Vector3 createPosition = new(_presentPosition.position.x, 
                _presentPosition.position.y + _productsMargin * i, 
                _presentPosition.position.z);
            Quaternion rotation = _selfCarrier.gameObject.transform.rotation;
            var product = _selfCarrier.Products[i];
            _products.Add(Instantiate(product.ProductModelForPresenter,
                createPosition,
                rotation,
                _selfCarrier.gameObject.transform).
                GetComponent<Product>()); 
        }
    }
    private void DeleteProducts()
    {
        if(_products.Count > 0)
        {
            for (int i = 0; i < _products.Count; i++)
            {
                Destroy(_products[i].gameObject);
            }
            _products.Clear();
        }
    }
}
