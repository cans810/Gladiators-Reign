using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRewardItem : MonoBehaviour
{
    public GameObject actual_Item;
    
    public Image itemImage;

    public UIReward uiReward;

    public void SetContainedItem(GameObject actualItem)
    {
        actual_Item = actualItem;
        
        // Get the sprite from the actual item
        Sprite itemSprite = actual_Item.GetComponent<SpriteRenderer>().sprite;
        
        // Set the image sprite to the item's sprite
        itemImage.sprite = itemSprite;

        // Set the size of the image to match the sprite's size
        RectTransform rt = itemImage.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(itemSprite.rect.width, itemSprite.rect.height);

        // Set the reward info from the item
        uiReward.RewardInfo = actual_Item.GetComponent<Armor>().details;
    }
}
