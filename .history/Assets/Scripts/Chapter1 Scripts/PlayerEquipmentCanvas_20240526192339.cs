using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipmentCanvas : MonoBehaviour
{
    public GameObject UIItemPrefab;

    public GameObject UI_Armors;

    // Start is called before the first frame update
    void Start()
    {
        foreach (ArmorData armor in Player.Instance.GetComponent<Inventory>().items){
            GameObject ui_armor = Instantiate(UIItemPrefab);
            ui_armor.transform.SetParent(UI_Armors, false);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
