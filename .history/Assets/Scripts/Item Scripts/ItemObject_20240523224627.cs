using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public ScriptableObject scriptableObject;

    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = scriptableObject.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
