using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsManager : MonoBehaviour
{
    public GladiatorManager glManager;

    public bool inAction;
    public bool isAnimating;

    private string currentAnimName; // to store the current animation name

    void Start()
    {
        glManager = GetComponent<GladiatorManager>();
    }

    public void StartAction(string animName)
    {
        inAction = true;
        isAnimating = true;
        currentAnimName = animName; // store the current action animation name
        glManager.animator.SetBool(animName, true);
    }

    public void StopAction(string animName)
    {
        inAction = false;
        isAnimating = false;
        if (currentAnimName == animName)
        {
            currentAnimName = null;
        }
        glManager.animator.SetBool(animName, false);
    }

    public void StartAnim(string animName)
    {
        isAnimating = true;
        currentAnimName = animName; // store the current animation name
        glManager.animator.SetBool(animName, true);
    }

    public void StopAnim(string animName)
    {
        isAnimating = false;
        if (currentAnimName == animName)
        {
            currentAnimName = null;
        }
        glManager.animator.SetBool(animName, false);
    }

    public void StopAllAnim()
    {
        Animator animator = glManager.animator;
        AnimatorStateInfo currentAnimState = animator.GetCurrentAnimatorStateInfo(0);

        if (currentAnimState.normalizedTime < 1.0f)
        {
            AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
            string currentAnimName = clipInfo[0].clip.name;
            StopAnim(currentAnimName);
        }
    }

    public void PlayCurrentAnimation()
    {
        if (!string.IsNullOrEmpty(currentAnimName))
        {
            glManager.animator.SetBool(currentAnimName, true);
        }
    }

    public bool IsAnimationPlaying()
    {
        Animator animator = glManager.animator;
        AnimatorStateInfo currentAnimState = animator.GetCurrentAnimatorStateInfo(0);

        // Check if the normalized time of the current animation is less than 1
        return currentAnimState.normalizedTime < 1.0f && animator.GetBool(currentAnimName);
    }
}
