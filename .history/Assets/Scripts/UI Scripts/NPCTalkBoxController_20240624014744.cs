using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTalkBoxController : MonoBehaviour
{
    TextWritingEffect writingEffect;
    public GameObject NPC;

    // Start is called before the first frame update
    void Start()
    {
        writingEffect = GetComponent<TextWritingEffect>();
        NPC_Talk(NPC);
    }

    public void NPC_Talk(GameObject NPC)
    {
        if (NPC != null)
        {
            var sellerController = NPC.GetComponent<MysteriousSellerController>();
            if (sellerController != null && !string.IsNullOrEmpty(sellerController.sentence_1))
            {
                writingEffect.AnimateText(sellerController.sentence_1);
                StartCoroutine(HandleNPCAnimation(sellerController));
            }
        }
    }

    private IEnumerator HandleNPCAnimation(MysteriousSellerController sellerController)
    {
        sellerController.talkingAnim(true); // Start talking animation

        // Wait for the text animation to finish
        while (writingEffect.IsAnimating())
        {
            yield return null;
        }

        sellerController.talkingAnim(false); // Stop talking animation
        sellerController.PlayIdleAnim(); // Start idle animation
    }
}
