using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBlacksmithController : MonoBehaviour
{
    public bool npcActive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToBlackSmithScene(){
        ScreenFadeController.Instance.FadeToScene("DungeonBlackSmithScene");
    }
}
