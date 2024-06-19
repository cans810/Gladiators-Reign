using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour
{
    public string itemName;

    public int armorPoint;
    public GameObject equippedBy;

    public SpriteRenderer spriteRenderer;

    public void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.sortingLayerName = "ui";
    }

    public void GetEquipped(GameObject equippedBy){
        this.equippedBy = equippedBy;

        spriteRenderer.sortingLayerName = equippedBy.GetComponent<EntitySortingLayerController>().currentSortingLayer;
    }
}
