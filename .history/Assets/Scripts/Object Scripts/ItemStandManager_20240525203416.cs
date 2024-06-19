using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStandManager : MonoBehaviour
{

    public Material spritesDefaultMaterial;
    public Material outlineMaterial;

    public GameObject itemContained;

    public GameObject itemInfoPopupPrefab;

    public bool isPopupInstantiated;

    // Start is called before the first frame update
    void Start()
    {
        isPopupInstantiated = false;
        itemContained = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showItemInfo(){
        if (!isPopupInstantiated){
            itemContained.GetComponent<SpriteRenderer>().material = outlineMaterial;

            GameObject infoPopup = Instantiate(itemInfoPopupPrefab);
            infoPopup.transform.SetParent(GameObject.Find("DungeonBlackSmithControllerCanvas").transform);
            infoPopup.transform.localScale = new Vector3(1, 1, 1);
            infoPopup.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 2, gameObject.transform.position.z);
            isPopupInstantiated = true;
        }
    }


}
