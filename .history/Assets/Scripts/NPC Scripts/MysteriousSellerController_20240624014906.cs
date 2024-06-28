using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteriousSellerController : MonoBehaviour
{
    public Animator animator;

    public string sentence_1;
    public string sentence_2;
    public string sentence_3;
    public string sentence_4;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }


    public void talkingAnim(bool value)
    {
        animator.SetBool("Talking", value);
    }

    public void idleAnim(bool value)
    {
        animator.SetBool("Idle", value);
    }
}
