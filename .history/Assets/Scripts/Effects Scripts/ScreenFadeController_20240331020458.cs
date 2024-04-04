using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenFadeController : MonoBehaviour
{
    public Animator animator;

    private string sceneName;

    // Ensure there's only one instance of ScreenFadeController
    private static ScreenFadeController instance;
    
    void Awake()
    {
        // Ensure only one instance of ScreenFadeController exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Don't destroy this object when loading new scenes
        }
        else
        {
            Destroy(gameObject); // If an instance already exists, destroy this one
        }
    }

    public void FadeToScene(string sceneName)
    {
        this.sceneName = sceneName;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(sceneName);
    }
}
