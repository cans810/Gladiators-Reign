using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Armor",menuName = "Armor")]
public class Armor : Item
{
    public bool equipped;

    public int armorPoint;

    public Sprite pair;
    public Armor(string itemName,Sprite texture,int armorPoint){
        this.itemName = itemName;
        this.texture = texture;
        this.armorPoint = armorPoint;
    }
}
