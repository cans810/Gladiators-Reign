using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiFightArrangerController : MonoBehaviour
{
    public static int gladiatorAmount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadHomeSceneToSelectFighters(){
        ScreenFadeController.Instance.FadeToScene("DungeonHomeScene");
        DungeonHomeController.sceneMode = "SelectFighters";
    }

    public static void randomFighterAmount(){
        gladiatorAmount = 3;
    }
}
