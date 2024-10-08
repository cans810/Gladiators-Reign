using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacialAnimsController : MonoBehaviour
{
    FacialFeatureManager ffManager;
    GLAttributes gLAttributes;

    public string eyeState;

    [SerializeField] private float blinkDuration = 0.1f;
    [SerializeField] private float minBlinkInterval = 2f;
    [SerializeField] private float maxBlinkInterval = 7f;

    // Start is called before the first frame update
    void Start()
    {
        gLAttributes = GetComponent<GLAttributes>();
        ffManager = GetComponent<FacialFeatureManager>();

        eyeState = "eyeNormal";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BlinkAnim(){
        eyeState = "eyeBlink";
        ffManager.eyes.GetComponent<SpriteRenderer>().sprite = ffManager.textures.GetSprite(gLAttributes.race + "Eyes", eyeState);

        // wait for some time and reset it back to normal 

        eyeState = "eyeNormal";
        ffManager.eyes.GetComponent<SpriteRenderer>().sprite = ffManager.textures.GetSprite(gLAttributes.race + "Eyes", eyeState);
    }
}
