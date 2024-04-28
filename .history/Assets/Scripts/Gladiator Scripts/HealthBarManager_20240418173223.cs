using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarManager : MonoBehaviour
{
    public Attributes attributes;
    public GameObject healthBarObject;
    public SpriteRenderer healthBarImage;

    // Start is called before the first frame update
    void Start()
    {
        healthBarImage.transform.Find("health").GetComponent<SpriteRenderer>();
        healthBarObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (attributes.gotHit){

        }
    }
}
