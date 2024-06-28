using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIReward : MonoBehaviour
{

    public TextMeshProUGUI nameTextObject;
    public TextMeshProUGUI quantityTextObject;
    public TextMeshProUGUI rewardDetailsTextObject;

    public int quantity;
    public string RewardName;
    public string RewardInfo;

    public void Start(){
        quantityTextObject.text = quantity.ToString();
    }

    public void showDetailsOnHover(){
        nameTextObject.text = RewardName;
        rewardDetailsTextObject.text = RewardInfo;
    }
}
