using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacialAnimsController : MonoBehaviour
{
    FacialFeatureManager ffManager;

    GLAttributes gLAttributes;

    // Start is called before the first frame update
    void Start()
    {
        gLAttributes = GetComponent<GLAttributes>();
        ffManager = GetComponent<FacialFeatureManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BlinkAnim(){
        ffManager.eyes.GetComponent<SpriteRenderer>().sprite = ffManager.textures.GetSprite(gLAttributes.race + "Eyes", "eyeBlink");

        // wait for some time and reset it back to normal 
    }
}
