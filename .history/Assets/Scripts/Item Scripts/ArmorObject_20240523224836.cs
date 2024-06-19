using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorObject : MonoBehaviour
{
    public Item scriptableObject;

    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = scriptableObject.texture;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
