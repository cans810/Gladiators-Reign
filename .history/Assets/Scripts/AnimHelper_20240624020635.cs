using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnyAnimManager
{
    public static bool IsAnimPlaying(string animationName, Animator animator){
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
            animator.SetBool(currentAnimName,fa)
            glManager.animationsManager.StopAnim(currentAnimName);
        }
    }
}
