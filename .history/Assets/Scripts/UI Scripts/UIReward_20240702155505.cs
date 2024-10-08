using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIReward : MonoBehaviour
{

    public GameObject detailsTab;

    public TextMeshProUGUI nameTextObject;
    public TextMeshProUGUI quantityTextObject;
    public TextMeshProUGUI rewardDetailsTextObject;

    public int quantity;
    public string RewardName;
    public string RewardInfo;

    public void Start(){
        detailsTab.SetActive(false);

        if (quantityTextObject != null){
            
        }

        quantityTextObject.text = quantity.ToString();
    }

    public void showDetailsOnHover(){
        detailsTab.SetActive(true);
        nameTextObject.text = RewardName;
        rewardDetailsTextObject.text = RewardInfo;
    }

    public void showDetailsOnHoverExit(){
        detailsTab.SetActive(false);
    }
}
