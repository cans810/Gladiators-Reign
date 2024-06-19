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
        }
    }
    public void selectChestplates(){
        removePrevArmors();
        DungeonBlackSmithData.SelectedPart = "Chestplate";

        for (int i=0; i<1; i++){
            GameObject chestplate = Instantiate(AllItemsContainer.Instance.allChestplates[i]);

            chestplate.transform.SetParent(UI_Armors.transform);
            chestplate.transform.localScale = new Vector3(1, 1, 1);
            chestplate.GetComponent<ClickableObject>().onClick.AddListener(() => selectItem(chestplate));
        }
    }
    public void selectShoulderguards(){
        removePrevArmors();
        DungeonBlackSmithData.SelectedPart = "Shoulderguard";

        for (int i=0; i<1; i++){
            GameObject shoulderGuard = Instantiate(AllItemsContainer.Instance.allShoulderguards[i]);

            shoulderGuard.transform.SetParent(UI_Armors.transform);
            shoulderGuard.transform.localScale = new Vector3(1, 1, 1);
            shoulderGuard.GetComponent<ClickableObject>().onClick.AddListener(() => selectItem(shoulderGuard));
        }
    }
    public void selectWristguards(){
        removePrevArmors();
        DungeonBlackSmithData.SelectedPart = "Wristguard";

        for (int i=0; i<1; i++){
            GameObject wristguard = Instantiate(AllItemsContainer.Instance.allWristGuards[i]);

            wristguard.transform.SetParent(UI_Armors.transform);
            wristguard.transform.localScale = new Vector3(1, 1, 1);
            wristguard.GetComponent<ClickableObject>().onClick.AddListener(() => selectItem(wristguard));
        }
    }
    public void selectPants(){
        removePrevArmors();
        DungeonBlackSmithData.SelectedPart = "Pant";

        for (int i=0; i<1; i++){
            GameObject pant = Instantiate(AllItemsContainer.Instance.allPants[i]);

            pant.transform.SetParent(UI_Armors.transform);
            pant.transform.localScale = new Vector3(1, 1, 1);
            pant.GetComponent<ClickableObject>().onClick.AddListener(() => selectItem(pant));
        }
    }
    public void selectLegguards(){
        removePrevArmors();
        DungeonBlackSmithData.SelectedPart = "Legguard";

        for (int i=0; i<1; i++){
            GameObject legguard = Instantiate(AllItemsContainer.Instance.allLegGuards[i]);

            legguard.transform.SetParent(UI_Armors.transform);
            legguard.transform.localScale = new Vector3(1, 1, 1);
            legguard.GetComponent<ClickableObject>().onClick.AddListener(() => selectItem(legguard));
        }
    }
    public void selectShinguards(){
        removePrevArmors();
        DungeonBlackSmithData.SelectedPart = "Shinguard";

        for (int i=0; i<1; i++){
            GameObject Shinguard = Instantiate(AllItemsContainer.Instance.allShinGuards[i]);

            Shinguard.transform.SetParent(UI_Armors.transform);
            Shinguard.transform.localScale = new Vector3(1, 1, 1);
            Shinguard.GetComponent<ClickableObject>().onClick.AddListener(() => selectItem(Shinguard));
        }
    }
    public void selectShoes(){
        DungeonBlackSmithData.SelectedPart = "Shoe";

        for (int i=0; i<1; i++){
            GameObject Shoe = Instantiate(AllItemsContainer.Instance.allShoes[i]);

            Shoe.transform.SetParent(UI_Armors.transform);
            Shoe.transform.localScale = new Vector3(1, 1, 1);
            Shoe.GetComponent<ClickableObject>().onClick.AddListener(() => selectItem(Shoe));
        }
    }

    public void ReturnToDungeon(){
        ScreenFadeController.Instance.FadeToScene("DungeonScene");
    }
}
