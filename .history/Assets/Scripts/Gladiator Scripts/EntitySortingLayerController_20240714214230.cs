using UnityEngine;

public class EntitySortingLayerController : MonoBehaviour
{
    private float lastYPosition;
    public Transform feetPos;
    [SerializeField] private float sortingScale = 100f; // Adjustable in inspector

    private void Start()
    {
        if (feetPos == null)
        {
            Debug.LogError("Feet position not set on " + gameObject.name);
            return;
        }
        lastYPosition = feetPos.position.y;
        SetSortingOrder(transform);
    }

    public void SetSortingOrder(Transform parent)
    {
        float feetYPos = feetPos.position.y;
        int baseSortingOrder = Mathf.RoundToInt(-feetYPos * sortingScale);
        
        ResetChildSortingOrders(parent);
        AdjustChildSortingOrder(parent, baseSortingOrder);
    }

    private void ResetChildSortingOrders(Transform parent)
    {
        foreach (Transform child in parent)
        {
            SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.sortingOrder = 0;
            }
            ResetChildSortingOrders(child);
        }
    }

    private void AdjustChildSortingOrder(Transform child, int baseSortingOrder)
    {
        SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.sortingOrder += baseSortingOrder;
        }

        foreach (Transform grandChild in child)
        {
            AdjustChildSortingOrder(grandChild, baseSortingOrder);
        }
    }

    public void Update()
    {
        if (feetPos == null) return;

        float currentYPosition = feetPos.position.y;
        if (!Mathf.Approximately(currentYPosition, lastYPosition))
        {
            lastYPosition = currentYPosition;
            SetSortingOrder(transform);
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