using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStandManager : MonoBehaviour
{
    public Material spritesLitDefaultMaterial;
    public Material outlineMaterial;

    public GameObject itemContained;
    public GameObject itemInfoPopupPrefab;

    private GameObject instantiatedPopup; // Store the instantiated popup
    public bool isPopupInstantiated;
    public float popupCooldown = 0.5f; // Cooldown time in seconds

    private bool canTogglePopup = true; // To check if the popup can be toggled

    void Start()
    {
        isPopupInstantiated = false;
        itemContained = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canTogglePopup)
        {
            showItemInfo();
        }
    }

    public void showItemInfo()
    {
        if (!canTogglePopup) return;

        if (!isPopupInstantiated)
        {
            itemContained.GetComponent<SpriteRenderer>().material = outlineMaterial;

            instantiatedPopup = Instantiate(itemInfoPopupPrefab);
            instantiatedPopup.transform.SetParent(GameObject.Find("DungeonBlackSmithControllerCanvas").transform);
            instantiatedPopup.transform.localScale = new Vector3(1, 1, 1);
            instantiatedPopup.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2.6f, gameObject.transform.position.z);
            isPopupInstantiated = true;
        }
        else
        {
            itemContained.GetComponent<SpriteRenderer>().material = spritesLitDefaultMaterial;
            Destroy(instantiatedPopup);
            instantiatedPopup = null;
            isPopupInstantiated = false;
        }

        // Start the cooldown coroutine
        StartCoroutine(PopupCooldownRoutine());
    }

    private IEnumerator PopupCooldownRoutine()
    {
        canTogglePopup = false; // Disable toggling
        yield return new WaitForSeconds(popupCooldown);
        canTogglePopup = true; // Enable toggling
    }
}
