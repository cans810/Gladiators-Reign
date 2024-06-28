using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnyAnimManager
{
    public static bool IsAnimPlaying(string animationName, Animator animator)
    {
        // Get the AnimatorStateInfo for the base layer
        AnimatorStateInfo currentAnimState = animator.GetCurrentAnimatorStateInfo(0);

        // Check if any animation is currently playing
        if (currentAnimState.normalizedTime < 1.0f)
        {
            // Get the current animation clip information
            AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);

            // Check if there's any clip information
            if (clipInfo.Length > 0)
            {
                // Get the clip name (assuming there's only one clip playing)
                string currentAnimName = clipInfo[0].clip.name;

                // Compare the current animation name with the given animation name
                return currentAnimName == animationName;
            }
        }

        // Return false if the animation is not playing or no clip information is found
        return false;
    }
}
