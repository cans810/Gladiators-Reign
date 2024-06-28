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

        if (NPC.GetComponent<MysteriousSellerController>)

        if (sentence_1 != null && sentence_1 != ""){
            writingEffect.AnimateText(sentence_1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
