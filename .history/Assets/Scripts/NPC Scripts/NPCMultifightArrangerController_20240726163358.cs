using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMultifightArrangerController : MonoBehaviour
{
    public static int gladiatorAmount;

    void Start()
    {
    }

    void Update()
    {
        // Additional update logic if needed
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
