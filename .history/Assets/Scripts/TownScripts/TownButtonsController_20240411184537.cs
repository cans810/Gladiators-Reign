using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TownButtonsController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Player.Instance.GetComponent<Attributes>().isAnimating = true;
        Player.Instance.GetComponent<Anim>().SetBool("RestCampfire",true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToHome(){
        ScreenFadeController.Instance.FadeToScene("HomeScene");
    }

    public void GoToArena(){
        ScreenFadeController.Instance.FadeToScene("ArenaScene");
    }
}
