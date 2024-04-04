using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    
    private bool hasCheckedScene = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        CheckCurrentScene();
    }

    private void CheckCurrentScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "TownScene")
        {
            
        }

        hasCheckedScene = true;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (!hasCheckedScene)
        {
            CheckCurrentScene();
        }
    }
}
