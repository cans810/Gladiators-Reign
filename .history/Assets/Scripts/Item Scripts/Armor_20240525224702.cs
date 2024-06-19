using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class Armor : Mono{
    public int armorPoint;
    public GameObject equippedBy;

    // public void Awake(){
    //     texture = GetComponent<SpriteRenderer>();

    //     texture.sortingLayerName = "ui";
    // }

    public void GetEquipped(GameObject equippedBy){
        this.equippedBy = equippedBy;

        texture.sortingLayerName = equippedBy.GetComponent<EntitySortingLayerController>().currentSortingLayer;
    }
}
