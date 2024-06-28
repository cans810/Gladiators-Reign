using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRewardGladiator : MonoBehaviour
{
    public GameObject gladiator_rewarded;
    
    public Image gladiatorHeadImage;

    public UIReward uiReward;

    public void SetRewardedGladiator(GameObject gladiator_rewarded){
        this.gladiator_rewarded = gladiator_rewarded;

        G

        gladiatorHeadImage.sprite = gladiator_rewarded.transform.Find("GladiatorModel").transform.Find("head").GetComponent<SpriteRenderer>().sprite;
        gladiatorHeadImage.color = 

        uiReward.RewardName = gladiator_rewarded.GetComponent<GLAttributes>().gladiator_name; // get it as item
    }
}
