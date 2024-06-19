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

    // Start is called before the first frame update
    void Start()
    {

        if (DungeonBlackSmithData.SelectedPart.Equals("Helmet")){
            for (int i=0; i<1; i++){
                GameObject ui_armor = Instantiate(UIItemPrefab);
                ui_armor.transform.SetParent(UI_Armors.transform);
                ui_armor.transform.localScale = new Vector3(1, 1, 1);
                ui_armor.GetComponent<ClickableObject>().onClick.AddListener(() => selectItem(ui_armor));

                ui_armor.GetComponent<UI_Item>().setItemUI(AllItemsContainer.Instance.allHelmets[i].GetComponent<Item>().itemName, AllItemsContainer.Instance.allHelmets[i].GetComponent<Item>().texture);

                GameObject helmet = Instantiate(AllItemsContainer.Instance.allHelmets[i]);

                helmet.transform.SetParent(UI_Armors.transform);
                helmet.transform.localScale = new Vector3(1, 1, 1);
                //helmet.GetComponent<ClickableObject>().onClick.AddListener(() => selectItem(helmet));

                //helmet.GetComponent<UI_Item>().setItemUI(armor.itemName, armor.texture);

            }
        }

        if (DungeonBlackSmithData.SelectedPart.Equals("Chestplate")){
            for (int i=0; i<1; i++){
                GameObject chestplate = Instantiate(AllItemsContainer.Instance.allChestplates[i]);

                chestplate.transform.SetParent(UI_Armors.transform);
                chestplate.transform.localScale = new Vector3(1, 1, 1);
                chestplate.GetComponent<ClickableObject>().onClick.AddListener(() => selectItem(chestplate));
            }
        }

        if (DungeonBlackSmithData.SelectedPart.Equals("Shoulderguard")){
            for (int i=0; i<1; i++){
                GameObject shoulderGuard = Instantiate(AllItemsContainer.Instance.allShoulderguards[i]);

                shoulderGuard.transform.SetParent(UI_Armors.transform);
                shoulderGuard.transform.localScale = new Vector3(1, 1, 1);
                shoulderGuard.GetComponent<ClickableObject>().onClick.AddListener(() => selectItem(shoulderGuard));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReturnToDungeon(){
        ScreenFadeController.Instance.FadeToScene("DungeonScene");
    }
}
