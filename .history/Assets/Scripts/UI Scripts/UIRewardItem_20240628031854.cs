using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRewardItem : MonoBehaviour
{
    public GameObject actual_Item;
    
    public Image itemImage;

    public UIReward uiReward;

    public void SetContainedItem(GameObject actualItem){
        actual_Item = actualItem;
        itemImage.sprite = actual_Item.GetComponent<SpriteRenderer>().sprite;
        itemImage.SetNativeSize();
        uiReward.RewardName = actual_Item.GetComponent<Armor>().details;// get it as item
        uiReward.RewardInfo = actual_Item.GetComponent<Armor>().details;// get it as item
    }
}
