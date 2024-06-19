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

    public int currentArmorIndex = 0;

    public void nextArmor(){
        if (currentArmorIndex < )

        UI_Armors.transform.GetChild(currentArmorIndex).gameObject.SetActive(false);
        currentArmorIndex++;
        UI_Armors.transform.GetChild(currentArmorIndex).gameObject.SetActive(true);

    }

    public void prevArmor(){
        UI_Armors.transform.GetChild(currentArmorIndex).gameObject.SetActive(false);
        currentArmorIndex--;
        UI_Armors.transform.GetChild(currentArmorIndex).gameObject.SetActive(true);
    }

    public void selectHelmets(){
        removePrevArmors();

        DungeonBlackSmithData.SelectedPart = "Helmet";

        for (int i=0; i<AllItemsContainer.Instance.allHelmets.Count; i++){
            GameObject ui_armor = Instantiate(uiItemPrefab);
            ui_armor.transform.SetParent(UI_Armors.transform);
            ui_armor.transform.localScale = new Vector3(1.6f, 1.6f, 1.6f);
            ui_armor.transform.localPosition = new Vector3(69, 0, 0);
            ui_armor.GetComponent<ClickableObject>().onClick.AddListener(() => selectItem(ui_armor));

            ui_armor.GetComponent<UI_Item>().setItemUI(AllItemsContainer.Instance.allHelmets[i].GetComponent<Armor>().itemName, 
            AllItemsContainer.Instance.allHelmets[i].GetComponent<Armor>().spriteRenderer.sprite);

            ui_armor.transform.Find("ItemTexture").GetComponent<Image>().SetNativeSize();
            ui_armor.transform.Find("ItemTexture").transform.localScale = new Vector3(4,4,4);

            if (i!=0){
                ui_armor.gameObject.SetActive(false);
            }
        }
    }
    public void selectChestplates(){
        removePrevArmors();
        DungeonBlackSmithData.SelectedPart = "Chestplate";

        for (int i=0; i<1; i++){
            GameObject ui_armor = Instantiate(uiItemPrefab);
            ui_armor.transform.SetParent(UI_Armors.transform);
            ui_armor.transform.localScale = new Vector3(1, 1, 1);
            ui_armor.transform.localPosition = new Vector3(475, 0, 0);
            ui_armor.GetComponent<ClickableObject>().onClick.AddListener(() => selectItem(ui_armor));

            ui_armor.GetComponent<UI_Item>().setItemUI(AllItemsContainer.Instance.allChestplates[i].GetComponent<Armor>().itemName, 
            AllItemsContainer.Instance.allChestplates[i].GetComponent<Armor>().spriteRenderer.sprite);

            ui_armor.transform.Find("ItemTexture").GetComponent<Image>().SetNativeSize();
            ui_armor.transform.Find("ItemTexture").transform.localScale = new Vector3(4,4,4);
        }
    }
    public void selectShoulderguards(){
        removePrevArmors();
        DungeonBlackSmithData.SelectedPart = "Shoulderguard";

        for (int i=0; i<1; i++){
            GameObject ui_armor = Instantiate(uiItemPrefab);
            ui_armor.transform.SetParent(UI_Armors.transform);
            ui_armor.transform.localScale = new Vector3(1, 1, 1);
            ui_armor.transform.localPosition = new Vector3(475, 0, 0);
            ui_armor.GetComponent<ClickableObject>().onClick.AddListener(() => selectItem(ui_armor));

            ui_armor.GetComponent<UI_Item>().setItemUI(AllItemsContainer.Instance.allShoulderguards[i].GetComponent<Armor>().itemName, 
            AllItemsContainer.Instance.allShoulderguards[i].GetComponent<Armor>().spriteRenderer.sprite);

            ui_armor.transform.Find("ItemTexture").GetComponent<Image>().SetNativeSize();
            ui_armor.transform.Find("ItemTexture").transform.localScale = new Vector3(4,4,4);
        }
    }
    public void selectWristguards(){
        removePrevArmors();
        DungeonBlackSmithData.SelectedPart = "Wristguard";

        for (int i=0; i<1; i++){
            GameObject ui_armor = Instantiate(uiItemPrefab);
            ui_armor.transform.SetParent(UI_Armors.transform);
            ui_armor.transform.localScale = new Vector3(1, 1, 1);
            ui_armor.transform.localPosition = new Vector3(475, 0, 0);
            ui_armor.GetComponent<ClickableObject>().onClick.AddListener(() => selectItem(ui_armor));

            ui_armor.GetComponent<UI_Item>().setItemUI(AllItemsContainer.Instance.allWristGuards[i].GetComponent<Armor>().itemName, 
            AllItemsContainer.Instance.allWristGuards[i].GetComponent<Armor>().spriteRenderer.sprite);

            ui_armor.transform.Find("ItemTexture").GetComponent<Image>().SetNativeSize();
            ui_armor.transform.Find("ItemTexture").transform.localScale = new Vector3(4,4,4);
        }
    }
    public void selectPants(){
        removePrevArmors();
        DungeonBlackSmithData.SelectedPart = "Pant";

        for (int i=0; i<1; i++){
            GameObject ui_armor = Instantiate(uiItemPrefab);
            ui_armor.transform.SetParent(UI_Armors.transform);
            ui_armor.transform.localScale = new Vector3(1, 1, 1);
            ui_armor.transform.localPosition = new Vector3(475, 0, 0);
            ui_armor.GetComponent<ClickableObject>().onClick.AddListener(() => selectItem(ui_armor));

            ui_armor.GetComponent<UI_Item>().setItemUI(AllItemsContainer.Instance.allPants[i].GetComponent<Armor>().itemName, 
            AllItemsContainer.Instance.allPants[i].GetComponent<Armor>().spriteRenderer.sprite);

            ui_armor.transform.Find("ItemTexture").GetComponent<Image>().SetNativeSize();
            ui_armor.transform.Find("ItemTexture").transform.localScale = new Vector3(4,4,4);
        }
    }
    public void selectLegguards(){
        removePrevArmors();
        DungeonBlackSmithData.SelectedPart = "Legguard";

        for (int i=0; i<1; i++){
            GameObject ui_armor = Instantiate(uiItemPrefab);
            ui_armor.transform.SetParent(UI_Armors.transform);
            ui_armor.transform.localScale = new Vector3(1, 1, 1);
            ui_armor.transform.localPosition = new Vector3(475, 0, 0);
            ui_armor.GetComponent<ClickableObject>().onClick.AddListener(() => selectItem(ui_armor));

            ui_armor.GetComponent<UI_Item>().setItemUI(AllItemsContainer.Instance.allLegGuards[i].GetComponent<Armor>().itemName, 
            AllItemsContainer.Instance.allLegGuards[i].GetComponent<Armor>().spriteRenderer.sprite);

            ui_armor.transform.Find("ItemTexture").GetComponent<Image>().SetNativeSize();
            ui_armor.transform.Find("ItemTexture").transform.localScale = new Vector3(4,4,4);
        }
    }
    public void selectShinguards(){
        removePrevArmors();
        DungeonBlackSmithData.SelectedPart = "Shinguard";

        for (int i=0; i<1; i++){
            GameObject ui_armor = Instantiate(uiItemPrefab);
            ui_armor.transform.SetParent(UI_Armors.transform);
            ui_armor.transform.localScale = new Vector3(1, 1, 1);
            ui_armor.transform.localPosition = new Vector3(475, 0, 0);
            ui_armor.GetComponent<ClickableObject>().onClick.AddListener(() => selectItem(ui_armor));

            ui_armor.GetComponent<UI_Item>().setItemUI(AllItemsContainer.Instance.allShinGuards[i].GetComponent<Armor>().itemName, 
            AllItemsContainer.Instance.allShinGuards[i].GetComponent<Armor>().spriteRenderer.sprite);

            ui_armor.transform.Find("ItemTexture").GetComponent<Image>().SetNativeSize();
            ui_armor.transform.Find("ItemTexture").transform.localScale = new Vector3(4,4,4);
        }
    }
    public void selectShoes(){
        removePrevArmors();
        DungeonBlackSmithData.SelectedPart = "Shoe";

        for (int i=0; i<1; i++){
            GameObject ui_armor = Instantiate(uiItemPrefab);
            ui_armor.transform.SetParent(UI_Armors.transform);
            ui_armor.transform.localScale = new Vector3(1, 1, 1);
            ui_armor.transform.localPosition = new Vector3(475, 0, 0);
            ui_armor.GetComponent<ClickableObject>().onClick.AddListener(() => selectItem(ui_armor));

            ui_armor.GetComponent<UI_Item>().setItemUI(AllItemsContainer.Instance.allShoes[i].GetComponent<Armor>().itemName, 
            AllItemsContainer.Instance.allShoes[i].GetComponent<Armor>().spriteRenderer.sprite);

            ui_armor.transform.Find("ItemTexture").GetComponent<Image>().SetNativeSize();
            ui_armor.transform.Find("ItemTexture").transform.localScale = new Vector3(4,4,4);
        }
    }

    public void ReturnToDungeon(){
        ScreenFadeController.Instance.FadeToScene("DungeonScene");
    }
}
