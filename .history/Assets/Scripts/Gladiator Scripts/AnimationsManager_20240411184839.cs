using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsManager : MonoBehaviour
{
    Attributes attributes;
    // Start is called before the first frame update
    void Start()
    {
        attributes = GetComponent<Attributes>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartAnim(string animName,bool isAnAction){
        if (isAnAction){
            attributes.inAction = true;
            attributes.isAnimating = true;
        }
        else{
            attributes.isAnimating = true;
        }
        
        attributes.animator.SetBool(animName,true);
    }

    public void StopAnim(string animName,bool isAnAction){
        if (isAnAction){
            attributes.inAction = true;
            attributes.isAnimating = true;
        }
        else{
            attributes.isAnimating = true;
        }
        
        attributes.animator.SetBool(animName,true);
    }
}
