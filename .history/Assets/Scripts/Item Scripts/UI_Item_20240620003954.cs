using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Item : MonoBehaviour
{
    public string itemName;

    public Image texture;
    public TextMeshProUGUI ite


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setItemUI(string itemName, Sprite texture){
        this.itemName = itemName;
        this.texture.sprite = texture;
    }
}
