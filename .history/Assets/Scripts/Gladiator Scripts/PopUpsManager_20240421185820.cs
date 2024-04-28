using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopUpsManager : MonoBehaviour
{
    public GameObject hitPopUpTextPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void HitPopUp(int amount_GotHit, GameObject opponent)
    {
        StartCoroutine(HitPopUpCoroutine(amount_GotHit, opponent));
    }

    IEnumerator HitPopUpCoroutine(int amount_GotHit, GameObject opponent)
    {
        // Randomize the position around the opponent
        float randomDistanceX = Random.Range(-0.7f, 0.7f);
        float randomDistanceY = Random.Range(1.f, 1.4f); // Adjust the Y range to position it above the opponent

        GameObject popup = Instantiate(hitPopUpTextPrefab);
        
        // Set the position of the popup
        Vector3 popupPosition = new Vector3(
            opponent.transform.position.x + randomDistanceX,
            opponent.transform.position.y + randomDistanceY,
            opponent.transform.position.z
        );
        popup.transform.position = popupPosition;

        // Set the sorting layer and order for rendering
        MeshRenderer popupMeshRenderer = popup.GetComponent<MeshRenderer>();
        if (popupMeshRenderer != null)
        {
            popupMeshRenderer.sortingLayerName = "ui"; // Ensure "UI" is the correct sorting layer name
            popupMeshRenderer.sortingOrder = 1000; // Adjust the sorting order as needed
        }
        else
        {
            Debug.LogError("MeshRenderer component not found in the child objects of the hitPopUpTextPrefab.");
        }

        // Set the text for the popup
        TextMeshPro textMeshPro = popup.GetComponentInChildren<TextMeshPro>();
        if (textMeshPro != null)
        {
            textMeshPro.text = amount_GotHit.ToString();
        }
        else
        {
            Debug.LogError("TextMeshPro component not found in the child objects of the hitPopUpTextPrefab.");
        }

        yield return new WaitForSeconds(1.8f);

        Destroy(popup);
    }
}
