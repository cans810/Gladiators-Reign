using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGuyController : MonoBehaviour
{
    public GameObject QuestGuyChatBox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void interactionPlot(){
        QuestGuyChatBox.transform.Find("Text").GetComponent<TextWritingEffect>().AnimateText("");
    }
}
