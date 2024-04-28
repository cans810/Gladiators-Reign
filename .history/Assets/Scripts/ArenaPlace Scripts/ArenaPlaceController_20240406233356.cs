using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaPlaceController : MonoBehaviour
{
    public Transform playerPosition;

    public GameObject 

    // Start is called before the first frame update
    void Start()
    {
        Player.Instance.GetComponent<Animator>().SetBool("RestCampfire",false);
        Player.Instance.gameObject.transform.position = playerPosition.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enterBattle(){
        ScreenFadeController.Instance.FadeToScene("BattleScene");
    }

    public void rejectBattle(){

    }
}
