using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStandManager : MonoBehaviour
{
    public Material spritesLitDefaultMaterial;
    public Material outlineMaterial;

    public GameObject itemContained;
    public GameObject itemInfoPopupPrefab;

    private GameObject instantiatedPopup;
    public bool isPopupInstantiated;
    public float popupCooldown = 0.4f;

    private bool canTogglePopup = true;

    public GameObject buyItemButton;

    void Start()
    {
        buyItemButton.SetActive(false);

        isPopupInstantiated = false;
        itemContained = transform.GetChild(1).gameObject;
    }

    void Update()
    {
    }

    public void showItemInfo()
    {
        if (!canTogglePopup) return;

        if (!isPopupInstantiated)
        {
            buyItemButton.SetActive(true);
            itemContained.GetComponent<SpriteRenderer>().material = outlineMaterial;

            instantiatedPopup = Instantiate(itemInfoPopupPrefab);
            instantiatedPopup.transform.SetParent(GameObject.Find("DungeonBlackSmithControllerCanvas").transform);
            instantiatedPopup.transform.localScale = new Vector3(1, 1, 1);
            instantiatedPopup.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2.6f, gameObject.transform.position.z);
            isPopupInstantiated = true;
        }
        else
        {
            buyItemButton.SetActive(false);
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
        canTogglePopup = false;
        yield return new WaitForSeconds(popupCooldown);
        canTogglePopup = true;
    }

    public void buyItem()
    {
        if (itemContained != null)
        {
            ArmorData itemDataToSave = ScriptableObject.CreateInstance<ArmorData>();
            itemDataToSave.itemName = itemContained.GetComponent<Armor>().itemName;
            itemDataToSave.armorPoint = itemContained.GetComponent<Armor>().armorPoint;
            itemDataToSave.texture = itemContained.GetComponent<Armor>().texture;

            Player.Instance.GetComponent<Inventory>().items.Add(itemDataToSave);

            // destroy the item stand's child object representing the item
            Destroy(itemContained);
            itemContained = null;
            buyItemButton.SetActive(false);
            itemContained.GetComponent<SpriteRenderer>().material = spritesLitDefaultMaterial;
            Destroy(instantiatedPopup);
            instantiatedPopup = null;
            isPopupInstantiated = false;

            Debug.Log("Bought item: " + itemDataToSave.itemName);
        }
        else
        {
            Debug.LogError("No item to buy or item data missing.");
        }
    }
}
