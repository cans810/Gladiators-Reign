using System.Collections;
using UnityEngine;

public class BattleArrangerController : MonoBehaviour
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

        SetIdle(true); // Start with idle animation
    }

    public IEnumerator TalkingStartDelay(){
        yield return new WaitForSeconds(1.0f);

        StartCoroutine(HandleTalkingAnimation());
    }

    public void StartTalking()
    {
        if (!string.IsNullOrEmpty(sentence_1))
        {
            writingEffect.AnimateText(sentence_1);
            StartCoroutine(TalkingStartDelay());
        }
    }

    private IEnumerator HandleTalkingAnimation()
    {
        SetIdle(false);
        SetTalking(true);

        // Wait for the text animation to finish
        while (writingEffect.IsAnimating())
        {
            yield return null;
        }

        SetTalking(false);
        SetIdle(true);
    }

    private void SetTalking(bool value)
    {
        animator.SetBool("Talking", value);
    }

    private void SetIdle(bool value)
    {
        animator.SetBool("Idle", value);
    }
}
