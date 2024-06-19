using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsManager : MonoBehaviour
{
    public GladiatorManager glManager;

    public bool inAction;
    public bool isAnimating;

    // Start is called before the first frame update
    void Start()
    {
        glManager = GetComponent<GladiatorManager>();
    }

    public void StartAction(string animName){
        inAction = true;
        
        isAnimating = true;
        
        glManager.animator.SetBool(animName,true);
    }

    public void StopAction(string animName){
        inAction = false;
        
        isAnimating = false;
        
        glManager.animator.SetBool(animName,false);
    }

    public void StartAnim(string animName){
        isAnimating = true;
  
        glManager.animator.SetBool(animName,true);
    }

    public void StopAnim(string animName){
        isAnimating = false;
  
        glManager.animator.SetBool(animName,false);
    }

    public void StopAllAnim(){
        // get the Animator component
        Animator animator = glManager.animator;

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
