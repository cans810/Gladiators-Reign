using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaPlaceController : MonoBehaviour
{
    public Transform playerPosition;

    public GameObject fightOption;
    public GameObject enterBattleButton;

    // Start is called before the first frame update
    void Start()
    {
        fightOption.SetActive(false);
        enterBattleButton.SetActive(false);

        //Player.Instance.transform.localScale = Player.Instance.GetComponent<GLAttributes>().battleSize;
        //Player.Instance.GetComponent<AnimationsManager>().StopAnim("RestCampfire");
       // Player.Instance.gameObject.transform.position = playerPosition.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enterBattle(){
        ScreenFadeController.Instance.FadeToScene("BattleScene");
    }

    public void rejectBattle(){
        fightOption.SetActive(false);
    }

    public void goBackToTown(){
        ScreenFadeController.Instance.FadeToScene("TownScene");

        //GameObject.Find("GladiatorGenerator").GetComponent<GladiatorGenerator>().destroyGeneratedGladiator();
        // place generated gladiator outside the screen
        //GameObject.Find("GladiatorGenerator").GetComponent<GladiatorGenerator>().hideGeneratedGladiator();
    }
}
