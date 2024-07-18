using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacialAnimsController : MonoBehaviour
{
    FacialFeatureManager ffManager;

    // Start is called before the first frame update
    void Start()
    {
        ffManager = GetComponent<FacialFeatureManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BlinkAnim(){
        ffManager.eyes.GetComponent<SpriteRenderer>().sprite = ffManager.textures.GetSprite("HumanEyes","eyeNormal");
    }
}
