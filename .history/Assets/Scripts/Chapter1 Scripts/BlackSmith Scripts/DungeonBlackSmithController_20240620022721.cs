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

    public void buySelectedItem(){
        GameManager.Instance.playerInventory.Add(AllItemsContainer.Instance.GetAnyArmor(currentSelectedItem.GetComponent<UI_Item>().itemName));
    }

    public void removePrevArmors(){
        foreach(Transform child in UI_Armors.transform){
            Destroy(child.gameObject);
        }
    }

    public int currentArmorIndex = 0;

    public void nextArmor(){
        if (currentArmorIndex + 1 < UI_Armors.transform.childCount){
            UI_Armors.transform.GetChild(currentArmorIndex).gameObject.SetActive(false);
            currentArmorIndex++;
            UI_Armors.transform.GetChild(currentArmorIndex).gameObject.SetActive(true);
            currentSelectedItem = UI_Armors.transform.GetChild(currentArmorIndex).gameObject;
        }
    }

    public void prevArmor(){
        if (currentArmorIndex - 1 >= 0){
            UI_Armors.transform.GetChild(currentArmorIndex).gameObject.SetActive(false);
            currentArmorIndex--;
            UI_Armors.transform.GetChild(currentArmorIndex).gameObject.SetActive(true);
            currentSelectedItem = UI_Armors.transform.GetChild(currentArmorIndex).gameObject;
        }
    }

    public void selectHelmets(){
        removePrevArmors();

        DungeonBlackSmithData.SelectedPart = "Helmet";

        for (int i=0; i<AllItemsContainer.Instance.allHelmets.Count; i++){
            GameObject ui_armor = Instantiate(uiItemPrefab);
            ui_armor.transform.SetParent(UI_Armors.transform);
            ui_armor.transform.localScale = new Vector3(1.6f, 1.6f, 1.6f);
            ui_armor.transform.localPosition = new Vector3(69, 0, 0);

            ui_armor.GetComponent<UI_Item>().setItemUI(AllItemsContainer.Instance.allHelmets[i].GetComponent<Armor>().itemName, 
            AllItemsContainer.Instance.allHelmets[i].GetComponent<Armor>().spriteRenderer.sprite);

            Destroy(ui_armor.GetComponent<ClickableObject>());

            ui_armor.transform.Find("ItemTexture").GetComponent<Image>().SetNativeSize();
            ui_armor.transform.Find("ItemTexture").transform.localScale = new Vector3(4,4,4);

            if (i!=0){
                ui_armor.gameObject.SetActive(false);
            }
        }

        currentArmorIndex = 0;
        UI_Armors.transform.GetChild(currentArmorIndex).gameObject.SetActive(true);
        currentSelectedItem = UI_Armors.transform.GetChild(currentArmorIndex).gameObject;
    }
    public void selectChestplates(){

        removePrevArmors();
        DungeonBlackSmithData.SelectedPart = "Chestplate";

        for (int i=0; i<AllItemsContainer.Instance.allChestplates.Count; i++){
            GameObject ui_armor = Instantiate(uiItemPrefab);
            ui_armor.transform.SetParent(UI_Armors.transform);
            ui_armor.transform.localScale = new Vector3(1.6f, 1.6f, 1.6f);
            ui_armor.transform.localPosition = new Vector3(69, 0, 0);

            ui_armor.GetComponent<UI_Item>().setItemUI(AllItemsContainer.Instance.allChestplates[i].GetComponent<Armor>().itemName, 
            AllItemsContainer.Instance.allChestplates[i].GetComponent<Armor>().spriteRenderer.sprite);

            Destroy(ui_armor.GetComponent<ClickableObject>());

            ui_armor.transform.Find("ItemTexture").GetComponent<Image>().SetNativeSize();
            ui_armor.transform.Find("ItemTexture").transform.localScale = new Vector3(4,4,4);

            if (i!=0){
                ui_armor.gameObject.SetActive(false);
            }
        }

        currentArmorIndex = 0;
        UI_Armors.transform.GetChild(currentArmorIndex).gameObject.SetActive(true);
        currentSelectedItem = UI_Armors.transform.GetChild(currentArmorIndex).gameObject;
    }
    public void selectShoulderguards(){
        removePrevArmors();
        DungeonBlackSmithData.SelectedPart = "Shoulderguard";

        for (int i=0; i<AllItemsContainer.Instance.allShoulderguards.Count; i++){
            GameObject ui_armor = Instantiate(uiItemPrefab);
            ui_armor.transform.SetParent(UI_Armors.transform);
            ui_armor.transform.localScale = new Vector3(1.6f, 1.6f, 1.6f);
            ui_armor.transform.localPosition = new Vector3(69, 0, 0);

            ui_armor.GetComponent<UI_Item>().setItemUI(AllItemsContainer.Instance.allShoulderguards[i].GetComponent<Armor>().itemName, 
            AllItemsContainer.Instance.allShoulderguards[i].GetComponent<Armor>().spriteRenderer.sprite);

            Destroy(ui_armor.GetComponent<ClickableObject>());

            ui_armor.transform.Find("ItemTexture").GetComponent<Image>().SetNativeSize();
            ui_armor.transform.Find("ItemTexture").transform.localScale = new Vector3(4,4,4);

            if (i!=0){
                ui_armor.gameObject.SetActive(false);
            }
        }

        currentArmorIndex = 0;
        UI_Armors.transform.GetChild(currentArmorIndex).gameObject.SetActive(true);
        currentSelectedItem = UI_Armors.transform.GetChild(currentArmorIndex).gameObject;
    }
    public void selectWristguards(){

        removePrevArmors();
        DungeonBlackSmithData.SelectedPart = "Wristguard";

        for (int i=0; i<AllItemsContainer.Instance.allWristGuards.Count; i++){
            GameObject ui_armor = Instantiate(uiItemPrefab);
            ui_armor.transform.SetParent(UI_Armors.transform);
            ui_armor.transform.localScale = new Vector3(1.6f, 1.6f, 1.6f);
            ui_armor.transform.localPosition = new Vector3(69, 0, 0);

            ui_armor.GetComponent<UI_Item>().setItemUI(AllItemsContainer.Instance.allWristGuards[i].GetComponent<Armor>().itemName, 
            AllItemsContainer.Instance.allWristGuards[i].GetComponent<Armor>().spriteRenderer.sprite);

            Destroy(ui_armor.GetComponent<ClickableObject>());

            ui_armor.transform.Find("ItemTexture").GetComponent<Image>().SetNativeSize();
            ui_armor.transform.Find("ItemTexture").transform.localScale = new Vector3(4,4,4);

            if (i!=0){
                ui_armor.gameObject.SetActive(false);
            }
        }

        currentArmorIndex = 0;
        UI_Armors.transform.GetChild(currentArmorIndex).gameObject.SetActive(true);
        currentSelectedItem = UI_Armors.transform.GetChild(currentArmorIndex).gameObject;
    }
    public void selectPants(){
        removePrevArmors();
        DungeonBlackSmithData.SelectedPart = "Pant";

        for (int i=0; i<AllItemsContainer.Instance.allPants.Count; i++){
            GameObject ui_armor = Instantiate(uiItemPrefab);
            ui_armor.transform.SetParent(UI_Armors.transform);
            ui_armor.transform.localScale = new Vector3(1.6f, 1.6f, 1.6f);
            ui_armor.transform.localPosition = new Vector3(69, 0, 0);

            ui_armor.GetComponent<UI_Item>().setItemUI(AllItemsContainer.Instance.allPants[i].GetComponent<Armor>().itemName, 
            AllItemsContainer.Instance.allPants[i].GetComponent<Armor>().spriteRenderer.sprite);

            Destroy(ui_armor.GetComponent<ClickableObject>());

            ui_armor.transform.Find("ItemTexture").GetComponent<Image>().SetNativeSize();
            ui_armor.transform.Find("ItemTexture").transform.localScale = new Vector3(4,4,4);

            if (i!=0){
                ui_armor.gameObject.SetActive(false);
            }
        }

        currentArmorIndex = 0;
        UI_Armors.transform.GetChild(currentArmorIndex).gameObject.SetActive(true);
        currentSelectedItem = UI_Armors.transform.GetChild(currentArmorIndex).gameObject;
    }
    public void selectLegguards(){
        removePrevArmors();
        DungeonBlackSmithData.SelectedPart = "Legguard";

        for (int i=0; i<AllItemsContainer.Instance.allLegGuards.Count; i++){
            GameObject ui_armor = Instantiate(uiItemPrefab);
            ui_armor.transform.SetParent(UI_Armors.transform);
            ui_armor.transform.localScale = new Vector3(1.6f, 1.6f, 1.6f);
            ui_armor.transform.localPosition = new Vector3(69, 0, 0);

            ui_armor.GetComponent<UI_Item>().setItemUI(AllItemsContainer.Instance.allLegGuards[i].GetComponent<Armor>().itemName, 
            AllItemsContainer.Instance.allLegGuards[i].GetComponent<Armor>().spriteRenderer.sprite);

            Destroy(ui_armor.GetComponent<ClickableObject>());

            ui_armor.transform.Find("ItemTexture").GetComponent<Image>().SetNativeSize();
            ui_armor.transform.Find("ItemTexture").transform.localScale = new Vector3(4,4,4);

            if (i!=0){
                ui_armor.gameObject.SetActive(false);
            }
        }

        currentArmorIndex = 0;
        UI_Armors.transform.GetChild(currentArmorIndex).gameObject.SetActive(true);
        currentSelectedItem = UI_Armors.transform.GetChild(currentArmorIndex).gameObject;
    }
    public void selectShinguards(){
        removePrevArmors();
        DungeonBlackSmithData.SelectedPart = "Shinguard";

        for (int i=0; i<AllItemsContainer.Instance.allShinGuards.Count; i++){
            GameObject ui_armor = Instantiate(uiItemPrefab);
            ui_armor.transform.SetParent(UI_Armors.transform);
            ui_armor.transform.localScale = new Vector3(1.6f, 1.6f, 1.6f);
            ui_armor.transform.localPosition = new Vector3(69, 0, 0);

            ui_armor.GetComponent<UI_Item>().setItemUI(AllItemsContainer.Instance.allShinGuards[i].GetComponent<Armor>().itemName, 
            AllItemsContainer.Instance.allShinGuards[i].GetComponent<Armor>().spriteRenderer.sprite);

            Destroy(ui_armor.GetComponent<ClickableObject>());

            ui_armor.transform.Find("ItemTexture").GetComponent<Image>().SetNativeSize();
            ui_armor.transform.Find("ItemTexture").transform.localScale = new Vector3(4,4,4);

            if (i!=0){
                ui_armor.gameObject.SetActive(false);
            }
        }

        currentArmorIndex = 0;
        currentSelectedItem = UI_Armors.transform.GetChild(currentArmorIndex).gameObject;
    }
    public void selectShoes(){

        removePrevArmors();
        DungeonBlackSmithData.SelectedPart = "Shoe";

        for (int i=0; i<AllItemsContainer.Instance.allShoes.Count; i++){
            GameObject ui_armor = Instantiate(uiItemPrefab);
            ui_armor.transform.SetParent(UI_Armors.transform);
            ui_armor.transform.localScale = new Vector3(1.6f, 1.6f, 1.6f);
            ui_armor.transform.localPosition = new Vector3(69, 0, 0);

            ui_armor.GetComponent<UI_Item>().setItemUI(AllItemsContainer.Instance.allShoes[i].GetComponent<Armor>().itemName, 
            AllItemsContainer.Instance.allShoes[i].GetComponent<Armor>().spriteRenderer.sprite);

            Destroy(ui_armor.GetComponent<ClickableObject>());

            ui_armor.transform.Find("ItemTexture").GetComponent<Image>().SetNativeSize();
            ui_armor.transform.Find("ItemTexture").transform.localScale = new Vector3(4,4,4);

            if (i != 0){
                ui_armor.gameObject.SetActive(false);
            }
        }
        
        currentArmorIndex = 0;
        currentSelectedItem = UI_Armors.transform.GetChild(currentArmorIndex).gameObject;
    }

    public void ReturnToDungeon(){
        ScreenFadeController.Instance.FadeToScene("DungeonScene");
    }
}
