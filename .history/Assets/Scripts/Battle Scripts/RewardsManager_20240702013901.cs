using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardsManager : MonoBehaviour
{
    public GameObject RewardsGrid;

    public GameObject reward_ItemPrefab;
    public GameObject reward_CoinPrefab;
    public GameObject reward_GladiatorPrefab;
    public GameObject reward_XPPrefab;

    public Transform firstItemPos;

    public float spacing; // Spacing between items


    private void PlaceReward(GameObject rewardGenerated)
    {
        RectTransform rectTransform = rewardGenerated.GetComponent<RectTransform>();

        float totalWidth = 0f;
        int itemCount = RewardsGrid.transform.childCount;

        for (int i = 0; i < itemCount; i++)
        {
            if (i != 0){
                RectTransform childRectTransform = RewardsGrid.transform.GetChild(i).GetComponent<RectTransform>();
                totalWidth += childRectTransform.rect.width + spacing;
            }
            else{
                RectTransform childRectTransform = RewardsGrid.transform.GetChild(i).GetComponent<RectTransform>();
                totalWidth += childRectTransform.rect.width;
            }
        }

        float newPositionX = firstItemPos.localPosition.x + totalWidth;
        rectTransform.anchoredPosition = new Vector2(newPositionX, firstItemPos.localPosition.y + 160);
    }


    public void rewardWithCoins()
    {
        GameObject rewardGenerated = Instantiate(reward_CoinPrefab, RewardsGrid.transform);
        PlaceReward(rewardGenerated);

        // Get the Image component and BoxCollider2D component
        Image imageComponent = rewardGenerated.GetComponent<Image>();
        BoxCollider2D boxCollider = rewardGenerated.GetComponent<BoxCollider2D>();

        RectTransform rectTransform = imageComponent.rectTransform;
        Vector2 size = rectTransform.rect.size;
        boxCollider.size = size;
        boxCollider.offset = Vector2.zero;
    }

    public void rewardWithItem()
    {
        GameObject rewardGenerated = Instantiate(reward_ItemPrefab, RewardsGrid.transform);
        rewardGenerated.GetComponent<UIRewardItem>().SetContainedItem(AllItemsContainer.Instance.allHelmets[0]);
        Image rewardImage = rewardGenerated.GetComponent<Image>();
        rewardImage.SetNativeSize();

        RectTransform rectTransform = rewardImage.rectTransform;
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x * 1.5f, rectTransform.sizeDelta.y * 1.5f); // Adjust scale factor as needed

        PlaceReward(rewardGenerated);

        // Get the Image component and BoxCollider2D component
        Image imageComponent = rewardGenerated.GetComponent<Image>();
        BoxCollider2D boxCollider = rewardGenerated.GetComponent<BoxCollider2D>();

        RectTransform rectTransform2 = imageComponent.rectTransform;
        Vector2 size = rectTransform2.rect.size;
        boxCollider.size = size;
        boxCollider.offset = Vector2.zero;
    }

    public void rewardWithGladiator(GameObject rewarded_gladiator)
    {
        GameObject rewardGenerated = Instantiate(reward_GladiatorPrefab, RewardsGrid.transform);
        rewardGenerated.GetComponent<UIRewardGladiator>().SetRewardedGladiator(rewarded_gladiator);
        Image rewardImage = rewardGenerated.GetComponent<Image>();
        rewardImage.SetNativeSize();

        RectTransform rectTransform = rewardImage.rectTransform;
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x * 1.5f, rectTransform.sizeDelta.y * 1.5f); // Adjust scale factor as needed

        PlaceReward(rewardGenerated);

        // Get the Image component and BoxCollider2D component
        Image imageComponent = rewardGenerated.GetComponent<Image>();
        BoxCollider2D boxCollider = rewardGenerated.GetComponent<BoxCollider2D>();

        RectTransform rectTransform2 = imageComponent.rectTransform;
        Vector2 size = rectTransform2.rect.size;
        boxCollider.size = size;
        boxCollider.offset = Vector2.zero;
    }

    public GameObject getRewardItem(){
        return reward_ItemPrefab.GetComponent<UIRewardItem>().actual_Item;
    }

    public GameObject getRewardCoin(){
        return reward_CoinPrefab.GetComponent<UIReward().;
    }

}
