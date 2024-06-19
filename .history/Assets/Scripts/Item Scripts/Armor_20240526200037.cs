using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Item
{
    public string itemName;

    public int armorPoint;
    public GameObject equippedBy;
    public Sprite texture;

    public SpriteRenderer spriteRenderer;

    public void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        texture = spriteRenderer.sprite;

        spriteRenderer.sortingLayerName = "ui";
    }
}
