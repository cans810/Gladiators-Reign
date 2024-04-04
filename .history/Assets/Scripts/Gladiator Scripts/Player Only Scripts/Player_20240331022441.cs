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
        if (currentScene.name == "YourSceneNameHere")
        {
            Debug.Log("Performing action for scene: " + currentScene.name);
        }

        // Set the flag to true so that we don't check the scene again
        hasCheckedScene = true;
    }

    // Example function to be called when a scene is loaded (can be assigned to SceneManager.sceneLoaded event)
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (!hasCheckedScene)
        {
            CheckCurrentScene();
        }
    }
}
