using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardsManager : MonoBehaviour
{
    public GameObject RewardsGrid;

    public GameObject reward_ItemPrefab;
    public GameObject reward_CoinPrefab;
    public GameObject reward_GladiatorPrefab;
    public GameObject reward_XPPrefab;

    public Transform firstItemPos;

    public float spacing = 10f; // Spacing between items

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlaceReward(GameObject rewardGenerated)
    {
        // Get the RectTransform of the newly generated item
        RectTransform rectTransform = rewardGenerated.GetComponent<RectTransform>();

        // Calculate the number of existing items
        int itemCount = RewardsGrid.transform.childCount - 1;

        // Calculate the new position for the item starting from firstItemPos
        float newPositionX = firstItemPos.localPosition.x;

        for (int i = 0; i < itemCount; i++)
        {
            RectTransform childRectTransform = RewardsGrid.transform.GetChild(i).GetComponent<RectTransform>();
            newPositionX += childRectTransform.rect.width + spacing;
        }

        rectTransform.anchoredPosition = new Vector2(newPositionX, firstItemPos.localPosition.y);
    }

    public void rewardWithCoins()
    {
        GameObject rewardGenerated = Instantiate(reward_CoinPrefab, RewardsGrid.transform);
        PlaceReward(rewardGenerated);
    }

    public void rewardWithItem()
    {
        GameObject rewardGenerated = Instantiate(reward_ItemPrefab, RewardsGrid.transform);
        rewardGenerated.GetComponent<UIRewardItem>().SetContainedItem(AllItemsContainer.Instance.allHelmets[0]);
        PlaceReward(rewardGenerated);
    }
}
