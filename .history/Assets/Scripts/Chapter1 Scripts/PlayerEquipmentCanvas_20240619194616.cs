using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipmentCanvas : MonoBehaviour
{
    public GameObject UIItemPrefab;

    public GameObject UI_Armors;

    public GameObject UI_Weapons;

    public GameObject currentSelectedItem;

    public GameObject selectedGladiator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showInventory(GameObject gladiator){
        selectedGladiator = gladiator;

        foreach (GameObject armor in GameManager.Instance.playerInventory){
            GameObject ui_armor = Instantiate(UIItemPrefab);
            ui_armor.transform.SetParent(UI_Armors.transform);
            ui_armor.transform.localScale = new Vector3(1, 1, 1);
            ui_armor.GetComponent<ClickableObject>().onClick.AddListener(() => selectItem(ui_armor));

            ui_armor.GetComponent<UI_Item>().setItemUI(armor.GetComponent<Armor>().itemName, armor.GetComponent<Armor>().texture);
        }
    }

    public void selectItem(GameObject itemToSelect){
        currentSelectedItem = itemToSelect;

        Debug.Log("selected item: " + currentSelectedItem.GetComponent<UI_Item>().itemName);
    }

    public void equipSelectedItem(){
        GameObject itemGenerated = null;
        GameObject itemGeneratedPair = null;

        if (currentSelectedItem.GetComponent<UI_Item>().itemName.Contains("Helmet")){
            GameObject foundItem = AllItemsContainer.Instance.GetHelmet(currentSelectedItem.GetComponent<UI_Item>().itemName);

            itemGenerated = Instantiate(foundItem);

            selectedGladiator.GetComponent<GLGearController>().WearHelmet(itemGenerated, AllItemsContainer.Instance.GetHelmet(currentSelectedItem.GetComponent<UI_Item>().itemName));
        }

        if (currentSelectedItem.GetComponent<UI_Item>().itemName.Contains("Chestplate")){
            itemGenerated = Instantiate(AllItemsContainer.Instance.GetChestplate(currentSelectedItem.GetComponent<UI_Item>().itemName));

            selectedGladiator.GetComponent<GLGearController>().WearChestplate(itemGenerated);
        }

        if (currentSelectedItem.GetComponent<UI_Item>().itemName.Contains("ShoulderGuard")){
            itemGenerated = Instantiate(AllItemsContainer.Instance.GetShoulderguard(currentSelectedItem.GetComponent<UI_Item>().itemName));
            itemGeneratedPair = Instantiate(AllItemsContainer.Instance.GetShoulderguard(currentSelectedItem.GetComponent<UI_Item>().itemName));

            selectedGladiator.GetComponent<GLGearController>().WearShoulderguard(itemGenerated , itemGeneratedPair);
        }

        if (currentSelectedItem.GetComponent<UI_Item>().itemName.Contains("WristGuard")){
            itemGenerated = Instantiate(AllItemsContainer.Instance.GetWristguard(currentSelectedItem.GetComponent<UI_Item>().itemName));
            itemGeneratedPair = Instantiate(AllItemsContainer.Instance.GetWristguard(currentSelectedItem.GetComponent<UI_Item>().itemName));

            selectedGladiator.GetComponent<GLGearController>().WearWristguard(itemGenerated , itemGeneratedPair);
        }

        if (currentSelectedItem.GetComponent<UI_Item>().itemName.Contains("Pants")){
            itemGenerated = Instantiate(AllItemsContainer.Instance.GetPant(currentSelectedItem.GetComponent<UI_Item>().itemName));

            selectedGladiator.GetComponent<GLGearController>().WearPants(itemGenerated);
        }

        if (currentSelectedItem.GetComponent<UI_Item>().itemName.Contains("Legguard")){
            itemGenerated = Instantiate(AllItemsContainer.Instance.GetLegGuard(currentSelectedItem.GetComponent<UI_Item>().itemName));
            itemGeneratedPair = Instantiate(AllItemsContainer.Instance.GetLegGuard(currentSelectedItem.GetComponent<UI_Item>().itemName));

            selectedGladiator.GetComponent<GLGearController>().WearLegguard(itemGenerated , itemGeneratedPair);
        }

        if (currentSelectedItem.GetComponent<UI_Item>().itemName.Contains("Shinguard")){
            itemGenerated = Instantiate(AllItemsContainer.Instance.GetShinGuard(currentSelectedItem.GetComponent<UI_Item>().itemName));
            itemGeneratedPair = Instantiate(AllItemsContainer.Instance.GetShinGuard(currentSelectedItem.GetComponent<UI_Item>().itemName));

            selectedGladiator.GetComponent<GLGearController>().WearShinguard(itemGenerated , itemGeneratedPair);
        }

        if (currentSelectedItem.GetComponent<UI_Item>().itemName.Contains("Shoe")){
            itemGenerated = Instantiate(AllItemsContainer.Instance.GetShoe(currentSelectedItem.GetComponent<UI_Item>().itemName));
            itemGeneratedPair = Instantiate(AllItemsContainer.Instance.GetShoe(currentSelectedItem.GetComponent<UI_Item>().itemName));

            selectedGladiator.GetComponent<GLGearController>().WearShoe(itemGenerated , itemGeneratedPair);
        }
    }

    public void unEquipSelectedItem(){
        if (currentSelectedItem.GetComponent<UI_Item>().itemName.Contains("Helmet")){
            selectedGladiator.GetComponent<GLGearController>().UnequipGear(GetComponent<GLGearController>().helmetSpot, null);
        }

        if (currentSelectedItem.GetComponent<UI_Item>().itemName.Contains("Chestplate")){
            selectedGladiator.GetComponent<GLGearController>().UnequipGear(GetComponent<GLGearController>().chestplateSpot, null);
        }

        if (currentSelectedItem.GetComponent<UI_Item>().itemName.Contains("ShoulderGuard")){
            selectedGladiator.GetComponent<GLGearController>().UnequipGear(GetComponent<GLGearController>().shoulderguardSpot_right, GetComponent<GLGearController>().shoulderguardSpot_left);
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
