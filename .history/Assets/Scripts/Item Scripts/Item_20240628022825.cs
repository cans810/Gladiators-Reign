using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;

    public Sprite texture;

    public SpriteRenderer spriteRenderer;

    public string 

    public void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        texture = spriteRenderer.sprite;

        spriteRenderer.sortingLayerName = "ui";
    }
}
