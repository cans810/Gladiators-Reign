using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMultifightArrangerController : MonoBehaviour
{
    public static int gladiatorAmount;

    public bool 

    void Start()
    {
    }

    void Update()
    {
    }

    public void loadHomeSceneToSelectFighters()
    {
        DungeonHomeController.sceneMode = "MultiFight";
        ScreenFadeController.Instance.FadeToScene("DungeonHomeScene");
    }

    public static void randomFighterAmount()
    {
        gladiatorAmount = 2;
    }
}
