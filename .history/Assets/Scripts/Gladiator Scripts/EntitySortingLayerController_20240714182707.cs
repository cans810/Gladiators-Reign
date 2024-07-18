using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntitySortingLayerController : MonoBehaviour
{
    public string currentSortingLayer;

    GLGearController gLGear;

    public void Start(){
        gLGear = GetComponent<GLGearController>();
    }

    public void SetSortingLayer(Transform parent, Transform enemyTransform)
    {
        if (enemyTransform != null){
            // Get the Y position of the parent GameObject
            float yPos = gameObject.transform.position.y;

            float enemyYPos = enemyTransform.position.y;
            string sortingLayerName = (yPos > enemyYPos) ? "behind" : "front";

            // Iterate through all child objects recursively
            foreach (Transform child in parent)
            {
                SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    // Set the sorting layer based on the comparison
                    spriteRenderer.sortingLayerName = sortingLayerName;
                    currentSortingLayer = sortingLayerName;
                }

                // Recursively set the sorting layer for child objects
                SetSortingLayer(child, enemyTransform);
            }
        }
    }
}
