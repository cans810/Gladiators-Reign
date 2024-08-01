using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBlacksmithController : NPCControllerBase
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToBlackSmithScene(){
        ScreenFadeController.Instance.FadeToScene("DungeonBlackSmithScene");
    }

    public string sentence_1;
    public string sentence_2;
    public string sentence_3;
    public string sentence_4;

    public TextWritingEffect writingEffect;
}
