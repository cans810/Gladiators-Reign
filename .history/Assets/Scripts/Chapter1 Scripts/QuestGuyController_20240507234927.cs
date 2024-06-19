using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGuyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void interactionPlot(){
        if (GameManager.Instance.isTimeForBattle() && !GameManager.Instance.recentlyFought){
            BattleArranger.SetActive(true);
            if (!informedPlayerAboutNewFight){
                BattleArrangerChatBox.transform.Find("Text").GetComponent<TextWritingEffect>().AnimateText("Gladiator, there is a battle awaiting you.");
                informedPlayerAboutNewFight = true;
            }
        }
        else{
            BattleArranger.SetActive(false);
            BattleArrangerChatBox.transform.Find("Text").GetComponent<TextWritingEffect>().AnimateText("");
            informedPlayerAboutNewFight = false;
        
    }
}
