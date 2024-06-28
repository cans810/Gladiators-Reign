using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIReward : MonoBehaviour
{

    public TextMeshProUGUI nameTextObject;
    public TextMeshProUGUI quantityTextObject;
    public TextMeshProUGUI rewardTextObject;

    public int quantity;
    public int RewardName;
    public string RewardInfo;

    public void Start(){
        quantityTextObject.text = quantity.ToString();
    }

    public void showDetailsOnHover(){
        nameTextObject.text 
        rewardTextObject.text = RewardInfo;
    }
}
