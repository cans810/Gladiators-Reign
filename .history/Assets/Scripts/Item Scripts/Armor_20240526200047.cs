using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Item
{

    public int armorPoint;
    public GameObject equippedBy;


    public void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        texture = spriteRenderer.sprite;

        spriteRenderer.sortingLayerName = "ui";
    }
}
