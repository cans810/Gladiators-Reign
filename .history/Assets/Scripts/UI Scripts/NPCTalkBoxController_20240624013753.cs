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

        if (NPC.GetComponent<MysteriousSellerController>()){
            NPC_Talk(NPC);
        }
    }

    public void NPC_Talk(GameObject NPC){
        if (sentence != null && sentence != ""){
            writingEffect.AnimateText(sentence);
        }
    }
}
