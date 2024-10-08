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
        // if (DungeonBlackSmithData.SelectedPart.Equals("Helmet")){
        //     for (int i=0; i<1; i++){
        //         GameObject ui_armor = Instantiate(uiItemPrefab);
        //         ui_armor.transform.SetParent(UI_Armors.transform);
        //         ui_armor.transform.localScale = new Vector3(1, 1, 1);
        //         ui_armor.GetComponent<ClickableObject>().onClick.AddListener(() => selectItem(ui_armor));

        //         ui_armor.GetComponent<UI_Item>().setItemUI(AllItemsContainer.Instance.allHelmets[i].GetComponent<Armor>().itemName, 
        //         AllItemsContainer.Instance.allHelmets[i].GetComponent<Armor>().spriteRenderer.sprite);
        //     }
        // }
    }

    public void removePrevArmors(){
        foreach(Transform child in UI_Armors.transform){
            Destroy(child.gameObject);
        }
    }

    public void selectHelmets(){
        removePrevArmors();

        DungeonBlackSmithData.SelectedPart = "Helmet";

        for (int i=0; i<1; i++){
            GameObject ui_armor = Instantiate(uiItemPrefab);
            ui_armor.transform.SetParent(UI_Armors.transform);
            ui_armor.transform.localScale = new Vector3(1, 1, 1);
            ui_armor.GetComponent<ClickableObject>().onClick.AddListener(() => selectItem(ui_armor));

            ui_armor.GetComponent<UI_Item>().setItemUI(AllItemsContainer.Instance.allHelmets[i].GetComponent<Armor>().itemName, 
            AllItemsContainer.Instance.allHelmets[i].GetComponent<Armor>().spriteRenderer.sprite);

            ui_armor.transform.Find("ItemTexture").transform.localScale = AllItemsContainer.Instance.allHelmets[i].transform.localScale;
        }
    }
    public void selectChestplates(){
        removePrevArmors();
        DungeonBlackSmithData.SelectedPart = "Chestplate";

        for (int i=0; i<1; i++){
            GameObject ui_armor = Instantiate(uiItemPrefab);
            ui_armor.transform.SetParent(UI_Armors.transform);
            ui_armor.transform.localScale = new Vector3(1, 1, 1);
            ui_armor.GetComponent<ClickableObject>().onClick.AddListener(() => selectItem(ui_armor));

            ui_armor.GetComponent<UI_Item>().setItemUI(AllItemsContainer.Instance.allChestplates[i].GetComponent<Armor>().itemName, 
            AllItemsContainer.Instance.allChestplates[i].GetComponent<Armor>().spriteRenderer.sprite);

            ui_armor.transform.Find("ItemTexture").transform.localScale = AllItemsContainer.Instance.allChestplates[i].transform.localScale;
        }
    }
    public void selectShoulderguards(){
        removePrevArmors();
        DungeonBlackSmithData.SelectedPart = "Shoulderguard";

        for (int i=0; i<1; i++){
            GameObject ui_armor = Instantiate(uiItemPrefab);
            ui_armor.transform.SetParent(UI_Armors.transform);
            ui_armor.transform.localScale = new Vector3(1, 1, 1);
            ui_armor.GetComponent<ClickableObject>().onClick.AddListener(() => selectItem(ui_armor));

            ui_armor.GetComponent<UI_Item>().setItemUI(AllItemsContainer.Instance.allShoulderguards[i].GetComponent<Armor>().itemName, 
            AllItemsContainer.Instance.allShoulderguards[i].GetComponent<Armor>().spriteRenderer.sprite);

            ui_armor.transform.Find("ItemTexture").transform.localScale = AllItemsContainer.Instance.allShoulderguards[i].transform.localScale;
        }
    }
    public void selectWristguards(){
        removePrevArmors();
        DungeonBlackSmithData.SelectedPart = "Wristguard";

        for (int i=0; i<1; i++){
            GameObject ui_armor = Instantiate(uiItemPrefab);
            ui_armor.transform.SetParent(UI_Armors.transform);
            ui_armor.transform.localScale = new Vector3(1, 1, 1);
            ui_armor.GetComponent<ClickableObject>().onClick.AddListener(() => selectItem(ui_armor));

            ui_armor.GetComponent<UI_Item>().setItemUI(AllItemsContainer.Instance.allWristGuards[i].GetComponent<Armor>().itemName, 
            AllItemsContainer.Instance.allWristGuards[i].GetComponent<Armor>().spriteRenderer.sprite);

            ui_armor.transform.Find("ItemTexture").transform.localScale = AllItemsContainer.Instance.allWristGuards[i].transform.localScale;
        }
    }
    public void selectPants(){
        removePrevArmors();
        DungeonBlackSmithData.SelectedPart = "Pant";

        for (int i=0; i<1; i++){
            GameObject ui_armor = Instantiate(uiItemPrefab);
            ui_armor.transform.SetParent(UI_Armors.transform);
            ui_armor.transform.localScale = new Vector3(1, 1, 1);
            ui_armor.GetComponent<ClickableObject>().onClick.AddListener(() => selectItem(ui_armor));

            ui_armor.GetComponent<UI_Item>().setItemUI(AllItemsContainer.Instance.allPants[i].GetComponent<Armor>().itemName, 
            AllItemsContainer.Instance.allPants[i].GetComponent<Armor>().spriteRenderer.sprite);

            ui_armor.transform.Find("ItemTexture").transform.localScale = AllItemsContainer.Instance.allPants[i].transform.localScale;
        }
    }
    public void selectLegguards(){
        removePrevArmors();
        DungeonBlackSmithData.SelectedPart = "Legguard";

        for (int i=0; i<1; i++){
            GameObject ui_armor = Instantiate(uiItemPrefab);
            ui_armor.transform.SetParent(UI_Armors.transform);
            ui_armor.transform.localScale = new Vector3(1, 1, 1);
            ui_armor.GetComponent<ClickableObject>().onClick.AddListener(() => selectItem(ui_armor));

            ui_armor.GetComponent<UI_Item>().setItemUI(AllItemsContainer.Instance.allLegGuards[i].GetComponent<Armor>().itemName, 
            AllItemsContainer.Instance.allLegGuards[i].GetComponent<Armor>().spriteRenderer.sprite);
        }
    }
    public void selectShinguards(){
        removePrevArmors();
        DungeonBlackSmithData.SelectedPart = "Shinguard";

        for (int i=0; i<1; i++){
            GameObject ui_armor = Instantiate(uiItemPrefab);
            ui_armor.transform.SetParent(UI_Armors.transform);
            ui_armor.transform.localScale = new Vector3(1, 1, 1);
            ui_armor.GetComponent<ClickableObject>().onClick.AddListener(() => selectItem(ui_armor));

            ui_armor.GetComponent<UI_Item>().setItemUI(AllItemsContainer.Instance.allShinGuards[i].GetComponent<Armor>().itemName, 
            AllItemsContainer.Instance.allShinGuards[i].GetComponent<Armor>().spriteRenderer.sprite);
        }
    }
    public void selectShoes(){
        removePrevArmors();
        DungeonBlackSmithData.SelectedPart = "Shoe";

        for (int i=0; i<1; i++){
            GameObject ui_armor = Instantiate(uiItemPrefab);
            ui_armor.transform.SetParent(UI_Armors.transform);
            ui_armor.transform.localScale = new Vector3(1, 1, 1);
            ui_armor.GetComponent<ClickableObject>().onClick.AddListener(() => selectItem(ui_armor));

            ui_armor.GetComponent<UI_Item>().setItemUI(AllItemsContainer.Instance.allShoes[i].GetComponent<Armor>().itemName, 
            AllItemsContainer.Instance.allShoes[i].GetComponent<Armor>().spriteRenderer.sprite);
        }
    }

    public void ReturnToDungeon(){
        ScreenFadeController.Instance.FadeToScene("DungeonScene");
    }
}
