using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour
{
    public int armorPoint;
    public GameObject equippedBy;

    public Sprite

    public void Awake(){
        texture = GetComponent<SpriteRenderer>();

        texture.sortingLayerName = "ui";
    }

    public void GetEquipped(GameObject equippedBy){
        this.equippedBy = equippedBy;

        texture.sortingLayerName = equippedBy.GetComponent<EntitySortingLayerController>().currentSortingLayer;
    }
}
