using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TownButtonsController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Player.Instance.GetComponent<Animator>().SetBool("RestCampfire",true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToHome(){
        ScreenFadeController.Instance.FadeToScene("HomeScene");
        SceneManager.LoadScene("HomeScene");
    }
}
