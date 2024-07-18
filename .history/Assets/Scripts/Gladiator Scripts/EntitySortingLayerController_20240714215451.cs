using UnityEngine;
using System.Collections.Generic;

public class EntitySortingLayerController : MonoBehaviour
{
    private float lastYPosition;
    public Transform feetPos;
    [SerializeField] private float sortingScale = 100f;
    private Dictionary<SpriteRenderer, int> originalSortingOrders = new Dictionary<SpriteRenderer, int>();
    

    private void Start()
    {
        if (feetPos == null)
        {
            Debug.LogError("Feet position not set on " + gameObject.name);
            return;
        }
        StoreOriginalSortingOrders(transform);
        lastYPosition = feetPos.position.y;
        SetSortingOrder();
    }

    private void StoreOriginalSortingOrders(Transform parent)
    {
        SpriteRenderer spriteRenderer = parent.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalSortingOrders[spriteRenderer] = spriteRenderer.sortingOrder;
        }

        foreach (Transform child in parent)
        {
            StoreOriginalSortingOrders(child);
        }
    }

    public void SetSortingOrder()
    {
        float feetYPos = feetPos.position.y;
        int baseSortingOrder = Mathf.RoundToInt(-feetYPos * sortingScale);
        
        AdjustChildSortingOrder(transform, baseSortingOrder);
    }

    private void AdjustChildSortingOrder(Transform obj, int baseSortingOrder)
    {
        SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null && originalSortingOrders.ContainsKey(spriteRenderer))
        {
            spriteRenderer.sortingOrder = baseSortingOrder + originalSortingOrders[spriteRenderer];
        }

        foreach (Transform child in obj)
        {
            AdjustChildSortingOrder(child, baseSortingOrder);
        }
    }

    public void Update()
    {
        if (feetPos == null) return;

        float currentYPosition = feetPos.position.y;
        if (!Mathf.Approximately(currentYPosition, lastYPosition))
        {
            lastYPosition = currentYPosition;
            SetSortingOrder();

            UpdateGearLayer();
        }
    }

    private void OnValidate()
    {
        if (feetPos == null)
        {
            Debug.LogWarning("Feet position not set on " + gameObject.name);
        }
    }
}