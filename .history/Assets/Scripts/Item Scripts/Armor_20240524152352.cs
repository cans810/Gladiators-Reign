using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour
{
    public string itemName;
    public int armorPoint;

    public SpriteRenderer texture;

    public GameObject equippedBy;

    public void Awake(){
        texture = GetComponent<SpriteRenderer>();

    }

    public void GetEquipped(GameObject equippedBy){
        
    }
}
