using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Item : MonoBehaviour
{
    public string itemName;

    public Image texture;


    // Start is called before the first frame update
    void Start()
    {
        texture = gameObject.transform.Find("ItemTexture").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setItemUI(string itemName, Sprite texture){
        this.itemName = itemName;
        this.texture = texture.texture;
    }
}
