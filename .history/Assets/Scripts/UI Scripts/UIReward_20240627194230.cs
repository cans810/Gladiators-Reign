using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIReward : MonoBehaviour
{
    public TextMeshProUGUI quantityTextObject;
    public TextMeshProUGUI rewardTextObject


    public string RewardInfo;

    public void Start(){
        quantityTextObject.text = quantity.ToString();
    }

    public void showDetailsOnHover(){
        rewardTextObject.text = RewardInfo;
    }
}
