using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour
{
    public int armorPoint;

    public Armor(string itemName, Sprite texture, int armorPoint){
        this.itemName = itemName;
        this.texture = texture;
        this.armorPoint = armorPoint;
    }
}
