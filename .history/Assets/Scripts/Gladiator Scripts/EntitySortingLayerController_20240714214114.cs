using UnityEngine;

public class EntitySortingLayerController : MonoBehaviour
{
    private float lastYPosition;

    public Transform feetPos;

    private void Start()
    {
        lastYPosition = feetPos.position.y;
        SetSortingOrder(transform);
    }

    public void SetSortingOrder(Transform parent)
    {
        // Get the Y position of the main parent GameObject

        float parentYPos = feetPos.position.y;

        // Calculate the base sorting order from the Y position
        int baseSortingOrder = -(int)(parentYPos * 100);

        // Iterate through all child objects of the parent
        foreach (Transform child in parent)
        {
            AdjustChildSortingOrder(child, baseSortingOrder);
        }
    }

    private void AdjustChildSortingOrder(Transform child, int baseSortingOrder)
    {
        SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            // Adjust the sorting order by adding the baseSortingOrder to the existing sorting order
            spriteRenderer.sortingOrder = baseSortingOrder + spriteRenderer.sortingOrder;
        }

        // Recursively adjust the sorting order for child objects
        foreach (Transform grandChild in child)
        {
            AdjustChildSortingOrder(grandChild, baseSortingOrder);
        }
    }

    public void Update()
    {
        // Check if the Y position has changed
        if (!Mathf.Approximately(feetPos.position.y, lastYPosition))
        {
            // Update the last Y position
            lastYPosition = feetPos.position.y;
            
            // Call SetSortingOrder only when the Y position has changed
            SetSortingOrder(transform);
        }
    }
}