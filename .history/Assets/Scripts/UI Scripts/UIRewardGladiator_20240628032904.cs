using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRewardGladiator : MonoBehaviour
{
    public GameObject gladiator_rewarded;
    
    public SpriteRenderer gladiatorHeadImage;

    public UIReward uiReward;

    public void SetContainedItem(GameObject gladiator_rewarded){
        this.gladiator_rewarded = gladiator_rewarded;

        gladiatorHeadImage = gladiator_rewarded.transform.Find("head").GetComponent<SpriteRenderer>();

        uiReward.RewardName = gladiator_rewarded.GetComponent<GLAttributes>().gladiator_name; // get it as item
    }
}
