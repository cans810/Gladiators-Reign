using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySortingLayerController : MonoBehaviour
{
    public void SetSortingOrder(Transform parent, Transform enemyTransform)
    {
        if (enemyTransform != null)
        {
            // Get the Y position of the parent GameObject
            float yPos = gameObject.transform.position.y;

            // Iterate through all child objects recursively
            foreach (Transform child in parent)
            {
                SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    // Set the sorting order based on the Y position, while preserving the existing sorting order
                    spriteRenderer.sortingOrder -= (int)(-yPos * 100);
                }

                // Recursively set the sorting order for child objects
                SetSortingOrder(child, enemyTransform);
            }
        }
    }
}
