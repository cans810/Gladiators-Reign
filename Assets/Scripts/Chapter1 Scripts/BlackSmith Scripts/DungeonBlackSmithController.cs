using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonBlackSmithController : MonoBehaviour
{
    public Material spriteLitMaterial;
    public GameObject uiItemPrefab;
    public GameObject UI_Armors;
    public GameObject currentSelectedItem;
    public int currentArmorIndex = 0;

    public void buySelectedItem()
    {
        if (currentSelectedItem != null)
        {
            GameManager.Instance.playerInventory.Add(AllItemsContainer.Instance.GetAnyArmor(currentSelectedItem.GetComponent<UI_Item>().itemName));
        }
    }

    public void removePrevArmors()
    {
        foreach (Transform child in UI_Armors.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void nextArmor()
    {
        if (currentArmorIndex + 1 < UI_Armors.transform.childCount)
        {
            UI_Armors.transform.GetChild(currentArmorIndex).gameObject.SetActive(false);
            currentArmorIndex++;
            UI_Armors.transform.GetChild(currentArmorIndex).gameObject.SetActive(true);
            currentSelectedItem = UI_Armors.transform.GetChild(currentArmorIndex).gameObject;
        }
    }

    public void prevArmor()
    {
        if (currentArmorIndex - 1 >= 0)
        {
            UI_Armors.transform.GetChild(currentArmorIndex).gameObject.SetActive(false);
            currentArmorIndex--;
            UI_Armors.transform.GetChild(currentArmorIndex).gameObject.SetActive(true);
            currentSelectedItem = UI_Armors.transform.GetChild(currentArmorIndex).gameObject;
        }
    }

    private IEnumerator SetCurrentSelectedItemWhenReady()
    {
        yield return new WaitUntil(() => UI_Armors.transform.childCount > 0);
        currentArmorIndex = 0;
        UI_Armors.transform.GetChild(currentArmorIndex).gameObject.SetActive(true);
        currentSelectedItem = UI_Armors.transform.GetChild(currentArmorIndex).gameObject;
    }

    private void PopulateArmors(List<GameObject> armors)
    {
        removePrevArmors();

        for (int i = 0; i < armors.Count; i++)
        {
            GameObject ui_armor = Instantiate(uiItemPrefab, UI_Armors.transform);
            ui_armor.transform.localScale = new Vector3(1.4f, 1.4f, 1.4f);
            ui_armor.transform.localPosition = new Vector3(66, 134, 0);

            Armor armor = armors[i].GetComponent<Armor>();
            ui_armor.GetComponent<UI_Item>().setItemUI(armor.itemName, armor.spriteRenderer.sprite);

            Destroy(ui_armor.GetComponent<ClickableObject>());

            Image itemTexture = ui_armor.transform.Find("ItemTexture").GetComponent<Image>();
            itemTexture.SetNativeSize();
            itemTexture.transform.localScale = new Vector3(4, 4, 4);

            ui_armor.SetActive(i == 0);
        }

        StartCoroutine(SetCurrentSelectedItemWhenReady());
    }

    public void selectHelmets()
    {
        PopulateArmors(AllItemsContainer.Instance.allHelmets);
    }

    public void selectChestplates()
    {
        PopulateArmors(AllItemsContainer.Instance.allChestplates);
    }

    public void selectShoulderguards()
    {
        PopulateArmors(AllItemsContainer.Instance.allShoulderguards);
    }

    public void selectWristguards()
    {
        PopulateArmors(AllItemsContainer.Instance.allWristGuards);
    }

    public void selectPants()
    {
        PopulateArmors(AllItemsContainer.Instance.allPants);
    }

    public void selectLegguards()
    {
        PopulateArmors(AllItemsContainer.Instance.allLegGuards);
    }

    public void selectShinguards()
    {
        PopulateArmors(AllItemsContainer.Instance.allShinGuards);
    }

    public void selectShoes()
    {
        PopulateArmors(AllItemsContainer.Instance.allShoes);
    }

    public void ReturnToDungeon()
    {
        ScreenFadeController.Instance.FadeToScene("DungeonScene");
    }
}
