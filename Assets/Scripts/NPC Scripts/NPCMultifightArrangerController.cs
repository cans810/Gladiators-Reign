using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMultifightArrangerController : NPCControllerBase
{
    public static int gladiatorAmount;

    public Animator animator;

    public string sentence_1;
    public string sentence_2;
    public string sentence_3;
    public string sentence_4;

    public TextWritingEffect writingEffect;

    public bool isTalking;

    void Start()
    {
        animator = GetComponent<Animator>();

        isTalking = false;
    }

    void Update()
    {
        if (npcActive && !isTalking){
            StartTalking();
        }
    }

    public void loadHomeSceneToSelectFighters()
    {
        DungeonHomeController.sceneMode = "MultiFight";
        ScreenFadeController.Instance.FadeToScene("DungeonHomeScene");
    }

    public static void randomFighterAmount()
    {
        gladiatorAmount = 2;
    }

    public IEnumerator TalkingStartDelay(){
        yield return new WaitForSeconds(1.0f);

        StartCoroutine(HandleTalkingAnimation());
    }

    public void StartTalking()
    {
        List<string> sentences = new List<string> { sentence_1, sentence_2, sentence_3, sentence_4 };
        sentences.RemoveAll(string.IsNullOrEmpty);

        if (sentences.Count > 0)
        {
            int randomIndex = Random.Range(0, sentences.Count);
            string randomSentence = sentences[randomIndex];

            isTalking = true;
            writingEffect.AnimateText(randomSentence);
            StartCoroutine(TalkingStartDelay());
        }
    }

    private IEnumerator HandleTalkingAnimation()
    {
        //SetIdle(false);
        //SetTalking(true);

        // Wait for the text animation to finish
        while (writingEffect.IsAnimating())
        {
            yield return null;
        }

        //SetTalking(false);
        //SetIdle(true);
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
