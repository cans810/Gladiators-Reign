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
        float randomDistanceX = Random.Range(-0.7f, 0.7f);
        float randomDistanceY = Random.Range(-0.7f, 0.7f);

        GameObject popup = Instantiate(hitPopUpTextPrefab);
        popup.transform.position = new Vector3(opponent.transform.position.x + randomDistanceX, opponent.transform.position.y + randomDistanceY, opponent.transform.position.z);

        Canvas popupCanvas = popup.GetComponent<Canvas>();
        if (popupCanvas != null)
        {
            // Ensure the popup canvas is rendered in front of everything
            popupCanvas.sortingOrder = int.MaxValue; // Set to the maximum value to ensure it's rendered on top
        }

        TextMeshPro textMeshPro = popup.GetComponentInChildren<TextMeshPro>();
        if (textMeshPro != null)
        {
            textMeshPro.text = amount_GotHit.ToString();
        }
        else
        {
            Debug.LogError("TextMeshProUGUI component not found in the child objects of the hitPopUpTextPrefab.");
        }

        yield return new WaitForSeconds(1.8f);

        Destroy(popup);
        
    }
}
