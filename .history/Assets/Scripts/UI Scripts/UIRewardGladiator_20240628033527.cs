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

        // Assuming gladiatorHeadImage is an Image component where you want to display the gladiator's head sprite
        SpriteRenderer headSpriteRenderer = gladiator_rewarded.transform.Find("head")?.GetComponent<SpriteRenderer>();
        if (headSpriteRenderer != null)
        {
            // Set the sprite of the gladiator's head
            gladiatorHeadImage.sprite = headSpriteRenderer.sprite;
        }
        else
        {
            Debug.LogWarning("Head sprite renderer not found on rewarded gladiator.");
            // Optionally set a default sprite or handle the case where the sprite is not found
        }

        // Assuming uiReward is an instance of a class or script where you set the reward name
        if (gladiator_rewarded.TryGetComponent(out GLAttributes gladiatorAttributes))
        {
            uiReward.RewardName = gladiatorAttributes.gladiator_name;
        }
        else
        {
            Debug.LogWarning("GLAttributes component not found on rewarded gladiator.");
            // Optionally set a default reward name or handle the case where GLAttributes component is not found
        }
    }

}
