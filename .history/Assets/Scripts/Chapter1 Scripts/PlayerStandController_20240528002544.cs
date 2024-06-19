using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStandController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void selectHelmet(){
        DungeonBlackSmithData.SelectedPart = "Helmet";
        ScreenFadeController.Instance.FadeToScene("DungeonBlackSmithScene");
    }

    public void selectChestplate(){
        DungeonBlackSmithData.SelectedPart = "Chestplate";
        ScreenFadeController.Instance.FadeToScene("DungeonBlackSmithScene");
    }

    public void selectShoulderguard(){
        DungeonBlackSmithData.SelectedPart = "Shoulderguard";
        ScreenFadeController.Instance.FadeToScene("DungeonBlackSmithScene");
    }
}
