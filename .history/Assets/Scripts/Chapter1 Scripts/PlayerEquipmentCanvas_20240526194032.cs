using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipmentCanvas : MonoBehaviour
{
    public GameObject UIItemPrefab;

    public GameObject UI_Armors;

    public GameObject UI_Weapons;

    // Start is called before the first frame update
    void Start()
    {
        foreach (ArmorData armor in Player.Instance.GetComponent<Inventory>().items){
            GameObject ui_armor = Instantiate(UIItemPrefab);
            ui_armor.transform.SetParent(UI_Armors.transform);
            ui_armor.transform.localScale = new Vector3(1, 1, 1);

            ui_armor.GetComponent<UI_Item>().setItemUI(armor.itemName, armor.texture);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseTab(){
        gameObject.SetActive(false);
    }
}
