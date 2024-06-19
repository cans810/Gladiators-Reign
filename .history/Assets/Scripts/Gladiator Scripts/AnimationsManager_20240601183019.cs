using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsManager : MonoBehaviour
{
    public Attributes attributes;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartAction(string animName){
        attributes.inAction = true;
        
        attributes.isAnimating = true;
        
        attributes.animator.SetBool(animName,true);
    }

    public void StopAction(string animName){
        attributes.inAction = false;
        
        attributes.isAnimating = false;
        
        attributes.animator.SetBool(animName,false);
    }

    public void StartAnim(string animName){
        attributes.isAnimating = true;
  
        attributes.animator.SetBool(animName,true);
    }

    public void StopAnim(string animName){
        attributes.isAnimating = false;
  
        attributes.animator.SetBool(animName,false);
    }

    
}
