using System.Collections;
using UnityEngine;

public class MysteriousSellerController : MonoBehaviour
{
    public Animator animator;

    public string sentence_1;
    public string sentence_2;
    public string sentence_3;
    public string sentence_4;

    public TextWritingEffect writingEffect;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        idleAnim(true);
    }

    public void StartTalking()
    {
        if (!string.IsNullOrEmpty(sentence_1))
        {
            writingEffect.AnimateText(sentence_1);
            StartCoroutine(HandleTalkingAnimation());
        }
    }

    private IEnumerator HandleTalkingAnimation()
    {
        idleAnim(false);
        talkingAnim(true); // Start talking animation

        // Wait for the text animation to finish
        while (writingEffect.IsAnimating())
        {
            yield return null;
        }

        talkingAnim(false); // Stop talking animation
        idleAnim(true); // Start idle animation
    }

    public void talkingAnim(bool value)
    {
        animator.SetBool("Talking", value);
    }

    public void idleAnim(bool value)
    {
        animator.SetBool("Idle", value);
    }

    public void glrChosenAnim(bool value)
    {
        animator.SetBool("Idle", value);
    }
}
