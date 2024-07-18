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
            float yPos = parent.position.y;
            float enemyYPos = enemyTransform.position.y;

            // Iterate through all child objects recursively
            foreach (Transform child in parent)
            {
                SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    // Set the sorting order based on the Y position
                    spriteRenderer.sortingOrder = (int)(-yPos * 100);
                }

                // Recursively set the sorting order for child objects
                SetSortingOrder(child, enemyTransform);
            }

            // Also set the sorting order for the enemy
            SpriteRenderer enemySpriteRenderer = enemyTransform.GetComponent<SpriteRenderer>();
            if (enemySpriteRenderer != null)
            {
                enemySpriteRenderer.sortingOrder = (int)(-enemyYPos * 100);
            }
        }
    }
}
