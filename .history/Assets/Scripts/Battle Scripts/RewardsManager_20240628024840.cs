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

    public float itemWidth = 100f;
    public float spacing = 10f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void rewardWithCoins(){
        GameObject rewardGenerated = Instantiate(reward_CoinPrefab, RewardsGrid.transform);

        float newPositionX = (rewardItems.Count * (itemWidth + spacing));
        newItem.GetComponent<RectTransform>().anchoredPosition = new Vector2(newPositionX, 0);
    }

    public void rewardWithItem(){
        GameObject rewardGenerated = Instantiate(reward_ItemPrefab, RewardsGrid.transform);
        rewardGenerated.GetComponent<UIRewardItem>().SetContainedItem(AllItemsContainer.Instance.allHelmets[0]);
    }
}
