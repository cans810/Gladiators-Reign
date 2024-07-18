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
    if (enemyTransform != null)
    {
        // Get the Y position of the current entity
        float yPos = transform.position.y;
        float enemyYPos = enemyTransform.position.y;

        // Calculate a small threshold to prevent flickering
        float threshold = 0.01f;

        string sortingLayerName;
        if (Mathf.Abs(yPos - enemyYPos) < threshold)
        {
            // If Y positions are very close, maintain current layer
            sortingLayerName = currentSortingLayer;
        }
        else
        {
            sortingLayerName = (yPos > enemyYPos) ? "front" : "behind";
        }

        // Update sorting layers only if there's a change
        if (sortingLayerName != currentSortingLayer)
        {
            currentSortingLayer = sortingLayerName;
            UpdateSortingLayersRecursively(parent, sortingLayerName);
        }
    }
}

private void UpdateSortingLayersRecursively(Transform parent, string sortingLayerName)
{
    SpriteRenderer spriteRenderer = parent.GetComponent<SpriteRenderer>();
    if (spriteRenderer != null)
    {
        spriteRenderer.sortingLayerName = sortingLayerName;
    }

    foreach (Transform child in parent)
    {
        UpdateSortingLayersRecursively(child, sortingLayerName);
    }
}
}
