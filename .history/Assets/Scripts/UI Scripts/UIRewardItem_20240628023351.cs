using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRewardItem : MonoBehaviour
{
    public GameObject actual_Item;
    
    public Image itemImage;

    public UIReward uiReward;

    // Start is called before the first frame update
    void Start()
    {
        uiReward = GetComponent<UIReward>();
    }

    public void SetContainedItem(GameObject actualItem){
        actual_Item = actualItem;
        itemImage.sprite = actual_Item.GetComponent<SpriteRenderer>().sprite;
        uiReward.RewardInfo = actual_Item.GetComponent<Armor>().details;
    }
}
