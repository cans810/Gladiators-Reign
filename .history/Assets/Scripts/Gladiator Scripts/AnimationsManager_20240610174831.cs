using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsManager : MonoBehaviour
{
    public Gladi attributes;
    // Start is called before the first frame update
    void Start()
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

    public void StopAllAnim(){
        // get the Animator component
        Animator animator = attributes.animator;

        // get the AnimatorStateInfo for the base layer
        AnimatorStateInfo currentAnimState = animator.GetCurrentAnimatorStateInfo(0);

        // check if any animation is currently playing
        if (currentAnimState.normalizedTime < 1.0f)
        {
            // get the current animation clip information
            AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);

            // get the clip name (assuming there's only one clip playing)
            string currentAnimName = clipInfo[0].clip.name;

            // set the boolean parameter with the current animation name
            GetComponent<AnimationsManager>().StopAnim(currentAnimName);
        }
    }


}
