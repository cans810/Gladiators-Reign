using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySortingLayerController : MonoBehaviour
{
    public void SetSortingOrder(Transform parent, Transform enemyTransform)
    {
        if (enemyTransform != null)
        {
            // Get the Y position of the main parent GameObject
            float parentYPos = parent.position.y;

            // Initialize base sorting order
            int baseSortingOrder = -(int)(parentYPos * 100);

            // Iterate through all child objects of the parent
            foreach (Transform child in parent)
            {
                SetChildSortingOrder(child, baseSortingOrder, 0);
            }
        }
    }

    private void SetChildSortingOrder(Transform child, int baseSortingOrder, int depth)
    {
        SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            // Set the sorting order based on the base order and depth to maintain internal hierarchy
            spriteRenderer.sortingOrder = baseSortingOrder + depth;
        }

        // Recursively set the sorting order for child objects with incremented depth
        foreach (Transform grandChild in child)
        {
            SetChildSortingOrder(grandChild, baseSortingOrder, depth + 1);
        }
    }
}
