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

    public float spacing = 100f; // Spacing between items

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
        RectTransform rectTransform = rewardGenerated.GetComponent<RectTransform>();

        int itemCount = RewardsGrid.transform.childCount - 1;

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
        rewardGenerated.GetComponent<Image>().SetNativeSize();
        rew

        PlaceReward(rewardGenerated);
    }
}
