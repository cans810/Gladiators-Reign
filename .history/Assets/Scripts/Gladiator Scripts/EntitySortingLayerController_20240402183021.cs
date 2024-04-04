using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySortingLayerController : MonoBehaviour
{

    

    public void SetSortingLayer(Transform parent, Transform enemyTransform)
    {
        foreach (Transform child in parent)
        {
            SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                // Compare the Y position of the child with the enemy's Y position
                float yPos = child.position.y;
                float enemyYPos = enemyTransform.position.y;
                string sortingLayerName = (yPos > enemyYPos) ? "front" : "behind";

                // Set the sorting layer based on the comparison
                spriteRenderer.sortingLayerName = sortingLayerName;
            }

            // Recursively set the sorting layer for child objects
            SetSortingLayer(child, enemyTransform);
        }
    }
}
