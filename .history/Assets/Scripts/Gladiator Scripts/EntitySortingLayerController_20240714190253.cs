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

            // Iterate through all child objects of the parent
            foreach (Transform child in parent)
            {
                SetChildSortingOrder(child, parentYPos);
            }
        }
    }

    private void SetChildSortingOrder(Transform child, float parentYPos)
    {
        SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            // Set the sorting order based on the Y position, ensuring lower Y positions get higher sorting order
            spriteRenderer.sortingOrder = -(int)(parentYPos * 100);
        }

        // Recursively set the sorting order for child objects
        foreach (Transform grandChild in child)
        {
            SetChildSortingOrder(grandChild, parentYPos);
        }
    }
}
