using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenFadeController : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeToLevel(string levelName){
        this.levelName = levelName;
        animator.SetTrigger("Fade_Out");
    }

    public void OnFadeComplete(){
        SceneManager.LoadScene(levelName);
    }
}
