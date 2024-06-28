using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTalkBoxController : MonoBehaviour
{
    TextWritingEffect writingEffect;
    public GameObject NPC;
    
    public string sentence_1;
    public string sentence_2;
    public string sentence_3;
    public string sentence_4;

    // Start is called before the first frame update
    void Start()
    {
        writingEffect = GetComponent<TextWritingEffect>();

        if (NPC.GetComponent<MysteriousSellerController>()){
            NPC_Talk()
        }
    }

    public void NPC_Talk(string sentence){
        if (sentence != null && sentence != ""){
            writingEffect.AnimateText(sentence);
        }
    }
}
