using System.Collections;
using UnityEngine;

public static class AnyAnimHelper
{
    public static bool IsAnimPlaying(string animationParameter, Animator animator)
    {
        // Get the AnimatorStateInfo for the base layer
        AnimatorStateInfo currentAnimState = animator.GetCurrentAnimatorStateInfo(0);

        // Check if any animation is currently playing
        if (currentAnimState.normalizedTime < 1.0f)
        {
            // Check if the current state matches the given animation parameter
            return animator.GetBool(animationParameter);
        }

        // Return false if the animation is not playing or no clip information is found
        return false;
    }
}
