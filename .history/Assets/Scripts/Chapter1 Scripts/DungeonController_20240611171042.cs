using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonController : MonoBehaviour
{
    public GameObject playerPos;
    public GameObject enterBattleButton;
    

    public void Awake(){
        enterBattleButton.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject playerGL in GameManager.Instance.playerGLs){
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToHome(){
        ScreenFadeController.Instance.FadeToScene("DungeonHomeScene");
    }

    public void EnterBattleButton(){
        ScreenFadeController.Instance.FadeToScene("BeforeBattleCellScene");
    }
}
