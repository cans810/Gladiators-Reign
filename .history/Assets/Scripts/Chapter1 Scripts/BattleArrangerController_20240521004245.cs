using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleArrangerController : MonoBehaviour
{
    public GameObject GladiatorGenerator;

    public GameObject BattleArranger;
    public GameObject BattleArrangerChatBox;
    public GameObject BattleArrangerCloseButton;
    public bool informedPlayerAboutNewFight;

    public bool firstBattleComplete;

    public void Awake(){
        informedPlayerAboutNewFight = false;
        BattleArrangerCloseButton.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!firstBattleComplete){
            BattleArranger.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
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

    public void Dungeons_BattleArrangerInteraction()
    {
        Player.Instance.GetComponent<CommonActions>().WalkToPoint(BattleArranger.transform.Find("playerPos").transform.position,2f);

        GladiatorGenerator.GetComponent<GladiatorGenerator>().Dungeons_GenerateRandomGladiator();

        StartCoroutine(BattleArrangerCloseButtonActiveCoroutine(true));
    }

    IEnumerator BattleArrangerCloseButtonActiveCoroutine(bool value){
        yield return new WaitForSeconds(1.1f);

        BattleArrangerCloseButton.SetActive(value);
    }

    public void Dungeons_BattleArrangerClosed()
    {
        Player.Instance.GetComponent<CommonActions>().WalkToPoint(GameObject.Find("DungeonControllerCanvas").transform.Find("playerPos").transform.position,2f);
    

        BattleArrangerCloseButton.SetActive(false);

        StartCoroutine(BattleArrangerClosedCoroutine());
    }

    IEnumerator BattleArrangerClosedCoroutine(){
        BattleArranger.GetComponent<ClickableObject>().isClickable = false;

        yield return new WaitForSeconds(1f);

        BattleArranger.GetComponent<ClickableObject>().isClickable = true;
        BattleArrangerCloseButton.SetActive(false);
    }
}
