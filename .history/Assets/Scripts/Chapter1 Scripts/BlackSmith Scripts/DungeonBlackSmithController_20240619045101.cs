using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonBlackSmithController : MonoBehaviour
{
    public Material spriteLitMaterial;

    public GameObject UI_Armors;

    public GameObject currentSelectedItem;

    public void selectItem(GameObject itemToSelect){
        currentSelectedItem = itemToSelect;

        Debug.Log("selected item: " + currentSelectedItem.GetComponent<UI_Item>().itemName);
    }

    public void Awake(){
        UI_Armors = GameObject.Find("");
        //Player.Instance.GetComponent<GLAttributes>().ChangeMaterial(spriteLitMaterial);
    }

    // Start is called before the first frame update
    void Start()
    {

        foreach (ArmorData armor in selectedGladiator.GetComponent<GLInventory>().items){
            GameObject ui_armor = Instantiate(UIItemPrefab);
            ui_armor.transform.SetParent(UI_Armors.transform);
            ui_armor.transform.localScale = new Vector3(1, 1, 1);
            ui_armor.GetComponent<ClickableObject>().onClick.AddListener(() => selectItem(ui_armor));

            ui_armor.GetComponent<UI_Item>().setItemUI(armor.itemName, armor.texture);

        }
        //Player.Instance.gameObject.transform.position = playerPos.transform.position;

        if (DungeonBlackSmithData.SelectedPart.Equals("Helmet")){
            for (int i=0; i<1; i++){
                GameObject helmet = Instantiate(AllItemsContainer.Instance.allHelmets[i]);
                helmet.GetComponent<Armor>().spriteRenderer.sortingLayerName = "middle";
                helmet.GetComponent<SpriteRenderer>().material = spriteLitMaterial;

                helmet.transform.SetParent(UI_Armors.transform);
                helmet.transform.localScale = new Vector3(1, 1, 1);
                helmet.GetComponent<ClickableObject>().onClick.AddListener(() => selectItem(helmet));

                //helmet.GetComponent<UI_Item>().setItemUI(armor.itemName, armor.texture);

            }
        }

        if (DungeonBlackSmithData.SelectedPart.Equals("Chestplate")){
            for (int i=0; i<1; i++){
                GameObject itemStand = Instantiate(itemStandPrefab);
                itemStand.transform.position = armorPoss[i].transform.position;
                itemStand.transform.position = new Vector2(itemStand.transform.position.x, itemStand.transform.position.y - 1.2f);
                itemStand.GetComponent<SpriteRenderer>().material = spriteLitMaterial;

                GameObject chestplate = Instantiate(AllItemsContainer.Instance.allChestplates[i]);
                chestplate.transform.position = armorPoss[i].transform.position;
                chestplate.transform.localScale = new Vector3(1f,1f,1f);
                chestplate.GetComponent<Armor>().spriteRenderer.sortingLayerName = "middle";
                chestplate.GetComponent<SpriteRenderer>().material = spriteLitMaterial;

                chestplate.transform.SetParent(itemStand.transform);
            }
        }

        if (DungeonBlackSmithData.SelectedPart.Equals("Shoulderguard")){
            for (int i=0; i<1; i++){
                GameObject itemStand = Instantiate(itemStandPrefab);
                itemStand.transform.position = armorPoss[i].transform.position;
                itemStand.transform.position = new Vector2(itemStand.transform.position.x, itemStand.transform.position.y - 1.2f);
                itemStand.GetComponent<SpriteRenderer>().material = spriteLitMaterial;

                GameObject shoulderguard = Instantiate(AllItemsContainer.Instance.allShoulderguards[i]);
                shoulderguard.transform.position = armorPoss[i].transform.position;
                shoulderguard.transform.localScale = new Vector3(1f,1f,1f);
                shoulderguard.GetComponent<Armor>().spriteRenderer.sortingLayerName = "middle";
                shoulderguard.GetComponent<SpriteRenderer>().material = spriteLitMaterial;

                shoulderguard.transform.SetParent(itemStand.transform);
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
