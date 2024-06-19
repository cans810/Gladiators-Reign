using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStandManager : MonoBehaviour
{
    public GameObject itemContained;

    public GameObject itemInfoPopupPrefab;

    public bool popupInstantiated;

    // Start is called before the first frame update
    void Start()
    {
        itemContained = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showItemInfo(){
        GameObject infoPopup = Instantiate(itemInfoPopupPrefab);
        infoPopup.transform.SetParent(GameObject.Find("DungeonBlackSmithControllerCanvas").transform);
    }


}
