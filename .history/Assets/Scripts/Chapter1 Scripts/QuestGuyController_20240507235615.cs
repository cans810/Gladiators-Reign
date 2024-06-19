using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGuyController : MonoBehaviour
{
    public GameObject QuestGuyChatBox;

    public GameObject questButton;

    // Start is called before the first frame update
    void Start()
    {
        questButton.SetActive(false);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void interactionPlot(){
        QuestGuyChatBox.transform.Find("Text").GetComponent<TextWritingEffect>().AnimateText("With what purpose you come?");
    }
}
