using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipmentCanvas : MonoBehaviour
{
    public GameObject UIItemPrefab;

    public GameObject UI_Armors;

    public GameObject UI_Weapons;

    public GameObject currentSelectedItem;

    // Start is called before the first frame update
    void Start()
    {
        foreach (ArmorData armor in Player.Instance.GetComponent<Inventory>().items){
            GameObject ui_armor = Instantiate(UIItemPrefab);
            ui_armor.transform.SetParent(UI_Armors.transform);
            ui_armor.transform.localScale = new Vector3(1, 1, 1);
            ui_armor.GetComponent<ClickableObject>().onClick.AddListener(() => selectItem(ui_armor));

            ui_armor.GetComponent<UI_Item>().setItemUI(armor.itemName, armor.texture);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void selectItem(GameObject itemToSelect){
        currentSelectedItem = itemToSelect;

        Debug.Log("selected item: " + currentSelectedItem.GetComponent<UI_Item>().itemName);
    }

    public void equipSelectedItem(){
        GameObject itemGenerated = null;
        GameObject itemGeneratedPair = null;

        if (currentSelectedItem.GetComponent<UI_Item>().itemName.Contains("Helmet")){
            itemGenerated = Instantiate(AllItemsContainer.Instance.GetHelmet(currentSelectedItem.GetComponent<UI_Item>().itemName));

            Player.Instance.GetComponent<GearController>().WearHelmet(itemGenerated);
        }

        if (currentSelectedItem.GetComponent<UI_Item>().itemName.Contains("Chestplate")){
            itemGenerated = Instantiate(AllItemsContainer.Instance.GetChestplate(currentSelectedItem.GetComponent<UI_Item>().itemName));

            Player.Instance.GetComponent<GearController>().WearChestplate(itemGenerated);
        }

        if (currentSelectedItem.GetComponent<UI_Item>().itemName.Contains("ShoulderGuard")){
            itemGenerated = Instantiate(AllItemsContainer.Instance.GetShoulderguard(currentSelectedItem.GetComponent<UI_Item>().itemName));
            itemGeneratedPair = Instantiate(AllItemsContainer.Instance.GetShoulderguard(currentSelectedItem.GetComponent<UI_Item>().itemName));

            Player.Instance.GetComponent<GearController>().WearShoulderguard(itemGenerated , itemGeneratedPair);
        }
    }

    public void equipSelectedItem(){
        GameObject itemGenerated = null;
        GameObject itemGeneratedPair = null;

        if (currentSelectedItem.GetComponent<UI_Item>().itemName.Contains("Helmet")){
            itemGenerated = Instantiate(AllItemsContainer.Instance.GetHelmet(currentSelectedItem.GetComponent<UI_Item>().itemName));

            Player.Instance.GetComponent<GearController>().WearHelmet(itemGenerated);
        }

        if (currentSelectedItem.GetComponent<UI_Item>().itemName.Contains("Chestplate")){
            itemGenerated = Instantiate(AllItemsContainer.Instance.GetChestplate(currentSelectedItem.GetComponent<UI_Item>().itemName));

            Player.Instance.GetComponent<GearController>().WearChestplate(itemGenerated);
        }

        if (currentSelectedItem.GetComponent<UI_Item>().itemName.Contains("ShoulderGuard")){
            itemGenerated = Instantiate(AllItemsContainer.Instance.GetShoulderguard(currentSelectedItem.GetComponent<UI_Item>().itemName));
            itemGeneratedPair = Instantiate(AllItemsContainer.Instance.GetShoulderguard(currentSelectedItem.GetComponent<UI_Item>().itemName));

            Player.Instance.GetComponent<GearController>().WearShoulderguard(itemGenerated , itemGeneratedPair);
        }
    }

    public void CloseTab(){
        gameObject.SetActive(false);
    }

    public void ShowArmors(){
        UI_Armors.SetActive(true);
        UI_Weapons.SetActive(false);
    }

    public void ShowWeapons(){
        UI_Armors.SetActive(false);
        UI_Weapons.SetActive(true);
    }
}
