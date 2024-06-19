using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonBlackSmithController : MonoBehaviour
{
    public Material spriteLitMaterial;

    public GameObject uiItemPrefab;

    public GameObject UI_Armors;

    public GameObject currentSelectedItem;

    public void selectItem(GameObject itemToSelect){
        currentSelectedItem = itemToSelect;

        Debug.Log("selected item: " + currentSelectedItem.GetComponent<UI_Item>().itemName);
    }

    public void buySelectedItem(){
        GameManager.Instance.playerInventory.Add(AllItemsContainer.Instance.GetAnyArmor(currentSelectedItem.GetComponent<UI_Item>().itemName));
    }

    // Start is called before the first frame update
    void Start()
    {
        if (DungeonBlackSmithData.SelectedPart.Equals("Helmet")){
            for (int i=0; i<1; i++){
                GameObject ui_armor = Instantiate(uiItemPrefab);
                ui_armor.transform.SetParent(UI_Armors.transform);
                ui_armor.transform.localScale = new Vector3(1, 1, 1);
                ui_armor.GetComponent<ClickableObject>().onClick.AddListener(() => selectItem(ui_armor));

                ui_armor.GetComponent<UI_Item>().setItemUI(AllItemsContainer.Instance.allHelmets[i].GetComponent<Armor>().itemName, 
                AllItemsContainer.Instance.allHelmets[i].GetComponent<Armor>().spriteRenderer.sprite);
            }
        }
    }

    public void selectHelmets(){
        DungeonBlackSmithData.SelectedPart = "Helmet";

        for (int i=0; i<1; i++){
            GameObject ui_armor = Instantiate(uiItemPrefab);
            ui_armor.transform.SetParent(UI_Armors.transform);
            ui_armor.transform.localScale = new Vector3(1, 1, 1);
            ui_armor.GetComponent<ClickableObject>().onClick.AddListener(() => selectItem(ui_armor));

            ui_armor.GetComponent<UI_Item>().setItemUI(AllItemsContainer.Instance.allHelmets[i].GetComponent<Armor>().itemName, 
            AllItemsContainer.Instance.allHelmets[i].GetComponent<Armor>().spriteRenderer.sprite);
        }
    }
    public void selectChestplates(){
        DungeonBlackSmithData.SelectedPart = "Chestplate";

        for (int i=0; i<1; i++){
            GameObject chestplate = Instantiate(AllItemsContainer.Instance.allChestplates[i]);

            chestplate.transform.SetParent(UI_Armors.transform);
            chestplate.transform.localScale = new Vector3(1, 1, 1);
            chestplate.GetComponent<ClickableObject>().onClick.AddListener(() => selectItem(chestplate));
        }
    }
    public void selectShoulderguards(){
        DungeonBlackSmithData.SelectedPart = "Shoulderguard";

        for (int i=0; i<1; i++){
            GameObject shoulderGuard = Instantiate(AllItemsContainer.Instance.allShoulderguards[i]);

            shoulderGuard.transform.SetParent(UI_Armors.transform);
            shoulderGuard.transform.localScale = new Vector3(1, 1, 1);
            shoulderGuard.GetComponent<ClickableObject>().onClick.AddListener(() => selectItem(shoulderGuard));
        }
    }
    public void selectWristguards(){
        DungeonBlackSmithData.SelectedPart = "Wristguard";

        for (int i=0; i<1; i++){
            GameObject wristguard = Instantiate(AllItemsContainer.Instance.allWristGuards[i]);

            shoulderGuard.transform.SetParent(UI_Armors.transform);
            shoulderGuard.transform.localScale = new Vector3(1, 1, 1);
            shoulderGuard.GetComponent<ClickableObject>().onClick.AddListener(() => selectItem(shoulderGuard));
        }
    }
    public void selectPants(){
        DungeonBlackSmithData.SelectedPart = "Pant";
    }
    public void selectLegguards(){
        DungeonBlackSmithData.SelectedPart = "Legguard";
    }
    public void selectShinguards(){
        DungeonBlackSmithData.SelectedPart = "Shinguard";
    }
    public void selectShoes(){
        DungeonBlackSmithData.SelectedPart = "Shoe";
    }

    public void ReturnToDungeon(){
        ScreenFadeController.Instance.FadeToScene("DungeonScene");
    }
}
