using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRewardGladiator : MonoBehaviour
{
    public GameObject gladiator_rewarded;
    
    public Image gladiatorHeadImage;

    public UIReward uiReward;

    public void SetRewardedGladiator(GameObject gladiator_rewarded)
    {
        this.gladiator_rewarded = gladiator_rewarded;

        SpriteRenderer headSpriteRenderer = gladiator_rewarded.transform.Find("GladiatorModel").transform.Find("head").GetComponent<SpriteRenderer>();
        if (headSpriteRenderer != null)
        {
            gladiatorHeadImage.sprite = headSpriteRenderer.sprite;
        }
        else
        {
            Debug.LogWarning("Head sprite renderer not found on rewarded gladiator.");
        }

        if (gladiator_rewarded.TryGetComponent(out GLAttributes gladiatorAttributes))
        {
            uiReward.RewardName = gladiatorAttributes.gladiator_name;
        }
        else
        {
            Debug.LogWarning("GLAttributes component not found on rewarded gladiator.");
        }
    }

}
