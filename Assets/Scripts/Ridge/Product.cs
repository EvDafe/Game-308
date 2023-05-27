using UnityEngine;

public class Product : MonoBehaviour
{
    [SerializeField] private GameObject _productModelForPresenter;

    public GameObject ProductModelForPresenter => _productModelForPresenter;
}
