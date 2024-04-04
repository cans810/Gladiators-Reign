using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenFadeController : MonoBehaviour
{
    public Animator animator;
    private string sceneName;

    public static ScreenFadeController Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void FadeToScene(string sceneName)
    {
        this.sceneName = sceneName;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(sceneName);
        animator.SetTrigger("FadeIn");
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Perform actions based on the loaded scene
        if (scene.name == "YourSceneNameHere")
        {
            // Do something specific to this scene
            Debug.Log("Loaded scene: " + scene.name);
        }
    }
}
