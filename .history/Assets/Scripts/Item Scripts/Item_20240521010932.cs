using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

[CreateAssetMenu(fileName ="New Item",menuName = "Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite texture;
    public string category;
}
