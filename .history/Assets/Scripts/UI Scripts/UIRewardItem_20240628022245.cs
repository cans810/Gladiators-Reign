using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRewardItem : MonoBehaviour
{
    public GameObject actual_Item;
    
    public Image itemImage;

    // Start is called before the first frame update
    void Start()
    {
        itemImage = actual_Item.GetComponent<SpriteRenderer>
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
